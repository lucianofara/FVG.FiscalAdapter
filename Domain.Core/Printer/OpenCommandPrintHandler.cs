using FiscalPrinterLib;
using FVG.FiscalAdapter.Domain.Core.Helpers;
using FVG.FiscalAdapter.Domain.Entities;
using System;

namespace FVG.FiscalAdapter.Domain.Core.Printer
{
    public class OpenCommandPrintHandler : _FiscalHandler, IPrintHandler<OpenCommandDocument>
    {
        public Result Print(OpenCommandDocument document)
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

                try
                {
                    //si hay un documento en curso busco el numero al cancelarlo
                    curso = printer.DocumentoEnCurso;
                    if (curso != Documentos.D_NO_DOCUMENTO_EN_CURSO)
                    {
                        ultimo = Comprobantes.GetUltimoComprobanteACancelar(curso, printer);
                        printer.TratarDeCancelarTodo();
                    }
                }
                catch (Exception)
                { }
                if (HasError(printer, document.Header, out message))
                    throw new Exception(message);

                //imprimir los comandos
                foreach (var command in document.Commands)
                    printer.Enviar(command);

                //pedir comprobate
                curso = printer.DocumentoEnCurso;
                int receipt = Comprobantes.GetUltimoComprobanteACancelar(curso, printer);

                printer.Finalizar();
                return new Success((ultimo != 0) ? ultimo.ToString() : string.Empty, receipt.ToString(), 0, curso.ToString());
            }
            catch (Exception ex)
            {
                printer.Abortar();
                try
                {
                    curso = printer.DocumentoEnCurso;
                    if (curso != Documentos.D_NO_DOCUMENTO_EN_CURSO)
                    {
                        ultimo = Comprobantes.GetUltimoComprobanteACancelar(curso, printer);
                        printer.TratarDeCancelarTodo();
                    }
                }
                catch (Exception)
                { }
                printer.Finalizar();
                return new Fail((ultimo != 0) ? ultimo.ToString() : string.Empty, ex.Message);
            }
        }
    }
}