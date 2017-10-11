using FiscalPrinterLib;
using FVG.FiscalAdapter.Domain.Core.Helpers;
using FVG.FiscalAdapter.Domain.Entities;
using System;

namespace FVG.FiscalAdapter.Domain.Core.Printer
{
    public class _FiscalHandler
    {
        public HASAR printer;
        public string message = string.Empty;

        public void printer_FaltaPapel()
        {
        }

        public void printer_ErrorFiscal(int Flags)
        {
            //solo para log
            string msj = "";
            switch (Flags)
            {
                case (int)FiscalPrinterLib.FiscalBits.F_INVALID_COMMAND:
                    msj = "Comando Inválido para el estado fiscal actual";
                    break;

                case (int)FiscalPrinterLib.FiscalBits.F_FISCAL_MEMORY_FAIL:
                    msj = "Ha ocurrido un error de chequeo de la memoria fiscal";
                    break;

                case (int)FiscalPrinterLib.FiscalBits.F_FISCAL_MEMORY_FULL:
                    msj = "La memoria de la impresora se ha llenado";
                    break;

                case (int)FiscalPrinterLib.FiscalBits.F_INVALID_FIELD_DATA:
                    msj = "Campo de datos invalido. Se ha rechazado el evento";
                    break;

                case (int)FiscalPrinterLib.FiscalBits.F_TOTAL_OVERFLOW:
                    msj = "Desborde de total. Intento de superar el monto limite para el comprobante";
                    break;

                case (int)FiscalPrinterLib.FiscalBits.F_UNRECOGNIZED_COMMAND:
                    msj = "Comando desconocido";
                    break;

                case (int)FiscalPrinterLib.FiscalBits.F_WORKING_MEMORY_FAIL:
                    msj = "Ha ocurrido un error de chequeo de la memoria de trabajo";
                    break;

                default:
                    msj = "Comando rechazado - Evento: ErrorFiscal( )";
                    break;
            };

            throw new Exception(msj);
        }

        public void printer_ImpresoraOcupada()
        {
        }

        public void printer_ErrorImpresora(int Flags)
        {
        }

        public bool HasError(HASAR printer, Header header, out string message)
        {
            message = string.Empty;
            if (printer.HuboErrorFiscal)
                message = "Ocurrio un error fiscal en la impresora: " + header.PrinterName;
            if (printer.HuboErrorMecanico)
                message = "Ocurrio un error mecanico en la impresora: " + header.PrinterName;
            if (printer.HuboFaltaPapel)
                message = "No hay papel en la impresora: " + header.PrinterName;
            return message != string.Empty;
        }

        public void Inicializar(HASAR printer, Header header)
        {
            printer.Transporte = TiposDeTransporte.SOCKET_TCP;
            printer.DireccionIP = header.Ip;
            printer.Puerto = header.Port;
            var modelo = Comprobantes.GetModeloFiscal(header.PrinterModel);
            if (modelo != null)
                printer.Modelo = (ModelosDeImpresoras)modelo;
            printer.ReintentoConstante = true;
            printer.FaltaPapel += printer_FaltaPapel;
            //para comandos este evento se ejecuta siempre por eso lo comento
            //printer.ErrorFiscal += printer_ErrorFiscal;
            printer.ErrorImpresora += printer_ErrorImpresora;
        }
    }
}