using FiscalPrinterLib;
using FVG.FiscalAdapter.Domain.Core.Helpers;
using FVG.FiscalAdapter.Domain.Entities;
using System;

namespace FVG.FiscalAdapter.Domain.Core.Printer
{
    public class CommandPrintHandler : _FiscalHandler, IPrintHandler<CommandDocument>
    {
        public Result Print(CommandDocument document)
        {
            int ultimo = 0;
            Documentos curso;
            try
            {
                printer = new HASAR();
                Inicializar(printer, document.Header);
                printer.Comenzar();
                if (HasError(printer, document.Header, out message))
                    throw new Exception(message);

                //si no hay comprobante abierto cancela
                curso = printer.DocumentoEnCurso;
                if (curso == Documentos.D_NO_DOCUMENTO_EN_CURSO)
                    throw new Exception("No hay documentos en curso iniciados");

                //imprimir los comandos
                foreach (var command in document.Commands)
                    printer.Enviar(command);

                double total = 0;
                printer.LeerMontoTotal(FiscalHelper.GetDocumentoIVA(curso), out total);

                DocPrinter doc = new DocPrinter();
                doc.Class = FiscalHelper.GetDocumentClass(curso);
                doc.DocDate = printer.FechaHoraFiscal;
                doc.PosNum = FiscalHelper.GetPosNumer(printer);
                doc.Type = FiscalHelper.GetDocumentType(curso);
                doc.DocNum = FiscalHelper.GetUltimoComprobanteACancelar(curso, printer).ToString();
                doc.TotalAmount = total;

                printer.Finalizar();
                return new Success(doc);
            }
            catch (Exception ex)
            {
                printer.Abortar();
                try
                {
                    curso = printer.DocumentoEnCurso;
                    if (curso != Documentos.D_NO_DOCUMENTO_EN_CURSO)
                    {
                        ultimo = FiscalHelper.GetUltimoComprobanteACancelar(curso, printer);
                        printer.TratarDeCancelarTodo();
                    }
                }
                catch (Exception)
                { }
                printer.Finalizar();
                return new Fail((ultimo == 0) ? string.Empty : ultimo.ToString(), ex.Message, ex);
            }
        }
    }
}