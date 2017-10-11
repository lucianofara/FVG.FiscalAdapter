namespace FVG.FiscalAdapter.Domain.Core.Helpers
{
    public class Result
    {
        public int Success { get; set; }
        public string Error { get; set; }
        public string Cancelado { get; set; }
        public Comprobante Comprobante { get; set; }

        public Result()
        {
            Success = 0;
            Error = string.Empty;
            Cancelado = string.Empty;
        }
    }

    public class Success : Result
    {
        public Success() : base()
        {
            Success = 1;
        }

        public Success(string cancelado) : base()
        {
            Success = 1;
            Cancelado = cancelado;
        }

        public Success(string cancelado, string comprobante, double importe, string tipoComprobante) : base()
        {
            Success = 1;
            Comprobante = new Comprobante()
            {
                Importe = importe,
                NroComprobante = comprobante,
                Tipo = tipoComprobante
            };
            Cancelado = cancelado;
        }

        public Success(string comprobante, double importe, string tipoComprobante) : base()
        {
            Success = 1;
            Comprobante = new Comprobante()
            {
                Importe = importe,
                NroComprobante = comprobante,
                Tipo = tipoComprobante
            };
        }
    }

    public class Fail : Result
    {
        public Fail(string error) : base()
        {
            Error = error;
        }

        public Fail(string cancelado, string error) : base()
        {
            Cancelado = cancelado;
            Error = error;
        }
    }

    public class Comprobante
    {
        public string Tipo { get; set; }
        public string NroComprobante { get; set; }
        public double Importe { get; set; }
    }
}