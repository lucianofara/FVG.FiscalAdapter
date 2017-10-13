using FiscalPrinterLib;

namespace FVG.FiscalAdapter.Domain.Core.Helpers
{
    public class FiscalHelper
    {
        public static DocumentosFiscales GetTipoComprobante(string codigo)
        {
            switch (codigo.Trim())
            {
                case "A":
                    return DocumentosFiscales.TICKET_FACTURA_A;

                case "B":
                    return DocumentosFiscales.TICKET_FACTURA_B;

                default:
                    return DocumentosFiscales.TICKET_FACTURA_B;
            }
        }

        public static DocumentosFiscales GetTipoComprobanteND(string codigo)
        {
            switch (codigo.Trim())
            {
                case "A":
                    return DocumentosFiscales.TICKET_NOTA_DEBITO_A;

                case "B":
                    return DocumentosFiscales.TICKET_NOTA_DEBITO_B;

                default:
                    return DocumentosFiscales.TICKET_NOTA_DEBITO_B;
            }
        }

        public static DocumentosNoFiscales GetTipoComprobanteNoFiscal(string codigo)
        {
            switch (codigo.Trim())
            {
                case "A":
                    return DocumentosNoFiscales.TICKET_NOTA_CREDITO_A;

                case "B":
                    return DocumentosNoFiscales.TICKET_NOTA_CREDITO_B;

                default:
                    return DocumentosNoFiscales.TICKET_NOTA_CREDITO_A;
            }
        }

        public static int GetUltimoComprobante(string codigo, HASAR impresora)
        {
            switch (codigo.Trim())
            {
                case "A":
                    return impresora.UltimoDocumentoFiscalA;

                case "B":
                    return impresora.UltimoDocumentoFiscalBC;

                default:
                    return 0;
            }
        }

        public static int GetUltimoComprobanteNC(string codigo, HASAR impresora)
        {
            switch (codigo.Trim())
            {
                case "A":
                    return impresora.UltimaNotaCreditoA;

                case "B":
                    return impresora.UltimaNotaCreditoBC;

                default:
                    return 0;
            }
        }

        public static TiposDocumentos TipoDocumento(string tipo)
        {
            switch (tipo.Trim())
            {
                case "FC":
                    return TiposDocumentos.FACTURA;

                case "ND":
                    return TiposDocumentos.NOTA_DEBITO;

                case "NC":
                    return TiposDocumentos.NOTA_CREDITO;

                default:
                    return TiposDocumentos.N_A;
            }
        }

        public static ModelosDeImpresoras? GetModeloFiscal(string modelo)
        {
            switch (modelo.Trim())
            {
                case "P-715F":
                    return ModelosDeImpresoras.MODELO_715_403;

                case "P-441F":
                    return ModelosDeImpresoras.MODELO_P441;

                default:
                    return null;
            }
        }

        public static int GetUltimoComprobanteACancelar(Documentos documento, HASAR printer)
        {
            switch (documento)
            {
                case Documentos.D_FACTURA_A:
                    return printer.UltimoDocumentoFiscalA;

                case Documentos.D_FACTURA_B:
                case Documentos.D_FACTURA_C:
                    return printer.UltimoDocumentoFiscalBC;

                case Documentos.D_NOTA_CREDITO_A:
                    return printer.UltimaNotaCreditoA;

                case Documentos.D_NOTA_CREDITO_B:
                case Documentos.D_NOTA_CREDITO_C:
                    return printer.UltimaNotaCreditoBC;

                default:
                    return 0;
            }
        }

        public static DocumentosIVA GetDocumentoIVA(Documentos documento)
        {
            switch (documento)
            {
                case Documentos.D_FACTURA_A:
                case Documentos.D_FACTURA_B:
                case Documentos.D_FACTURA_C:
                    return DocumentosIVA.DOCUMENTOS_FISCALES;

                case Documentos.D_NOTA_CREDITO_A:
                case Documentos.D_NOTA_CREDITO_B:
                case Documentos.D_NOTA_CREDITO_C:
                    return DocumentosIVA.NOTAS_DE_CREDITO;

                default:
                    return DocumentosIVA.DOCUMENTOS_FISCALES;
            }
        }

        public static string GetDocumentClass(Documentos documento)
        {
            switch (documento)
            {
                case Documentos.D_FACTURA_A:
                case Documentos.D_FACTURA_B:
                case Documentos.D_FACTURA_C:
                    return "FC";

                case Documentos.D_NOTA_CREDITO_A:
                case Documentos.D_NOTA_CREDITO_B:
                case Documentos.D_NOTA_CREDITO_C:
                    return "NC";

                default:
                    return "";
            }

        }

        public static string GetDocumentType(Documentos documento)
        {
            switch (documento)
            {
                case Documentos.D_FACTURA_A:
                case Documentos.D_NOTA_CREDITO_A:
                    return "A";
                case Documentos.D_NOTA_CREDITO_B:
                case Documentos.D_FACTURA_B:
                    return "B";
                case Documentos.D_FACTURA_C:
                case Documentos.D_NOTA_CREDITO_C:
                    return "C";
                default:
                    return "";
            }
        }

        public static string GetPosNumer(HASAR printer)
        {
            object cuit = string.Empty;
            object razonSocial = string.Empty;
            object numeroDeSerie = string.Empty;
            object fechaInicializacion = string.Empty;
            object numeroDePos = string.Empty;
            object inicioDeActividades = string.Empty;
            object codigoDeIngresosBrutos = string.Empty;
            object responsabilidadAnteIva = string.Empty;

            printer.ObtenerDatosDeInicializacion(out cuit, out razonSocial, out numeroDeSerie, out fechaInicializacion, out numeroDePos, out inicioDeActividades, out codigoDeIngresosBrutos, out responsabilidadAnteIva);
            return numeroDePos.ToString();
        }

        public enum TiposDocumentos
        {
            FACTURA,
            NOTA_CREDITO,
            NOTA_DEBITO,
            N_A
        }
    }
}