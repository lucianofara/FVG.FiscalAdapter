using FiscalPrinterLib;

namespace FVG.FiscalAdapter.Domain.Core.Helpers
{
    public class TipoCondicionIVA
    {
        public static TiposDeResponsabilidades GetTipoIVA(string codigo)
        {
            switch (codigo.Trim())
            {
                case "1":
                    return TiposDeResponsabilidades.RESPONSABLE_INSCRIPTO;

                case "7":
                    return TiposDeResponsabilidades.MONOTRIBUTO;

                case "3":
                    return TiposDeResponsabilidades.NO_CATEGORIZADO;

                case "4":
                    return TiposDeResponsabilidades.RESPONSABLE_EXENTO;

                case "5":
                    return TiposDeResponsabilidades.MONOTRIBUTO;

                case "48":
                    return TiposDeResponsabilidades.CONSUMIDOR_FINAL;

                case "6":
                    return TiposDeResponsabilidades.RESPONSABLE_NO_INSCRIPTO;

                case "2":
                    return TiposDeResponsabilidades.CONSUMIDOR_FINAL;

                default:
                    return TiposDeResponsabilidades.NO_CATEGORIZADO;
            }
        }
    }
}