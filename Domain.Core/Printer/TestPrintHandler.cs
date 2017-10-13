using FiscalPrinterLib;
using FVG.FiscalAdapter.Domain.Core.Helpers;
using FVG.FiscalAdapter.Domain.Entities;
using System;

namespace FVG.FiscalAdapter.Domain.Core.Printer
{
    public class TestPrintHandler : _FiscalHandler, IPrintHandler<TestDocument>
    {
        public Result Print(TestDocument document)
        {
            try
            {
                printer = new HASAR();
                Inicializar(printer, document.Header);
                printer.Comenzar();
                if (HasError(printer, document.Header, out message))
                    throw new Exception(message);
                try
                {
                    printer.TratarDeCancelarTodo();
                }
                catch (System.Exception)
                { }
                if (HasError(printer, document.Header, out message))
                    throw new Exception(message);
                printer.BorrarFantasiaEncabezadoCola(false, false, true);
                printer.AbrirComprobanteNoFiscal();

                printer.ImprimirTextoNoFiscal("Impresora:" + document.Header.PrinterName);
                printer.ImprimirTextoNoFiscal("IP:" + document.Header.Ip);
                printer.ImprimirTextoNoFiscal("Puerto:" + document.Header.Port.ToString());
                printer.ImprimirTextoNoFiscal("Sucursal:" + document.Header.Channel);
                printer.ImprimirTextoNoFiscal("Caja:" + document.Header.Registry);

                if (HasError(printer, document.Header, out message))
                    throw new Exception(message);
                printer.CerrarComprobanteNoFiscal();
                printer.Finalizar();
                return new Success();
            }
            catch (Exception ex)
            {
                printer.Abortar();
                try
                {
                    printer.TratarDeCancelarTodo();
                }
                catch (Exception)
                { }
                printer.Finalizar();
                return new Fail(ex.Message, ex);
            }
        }
    }
}