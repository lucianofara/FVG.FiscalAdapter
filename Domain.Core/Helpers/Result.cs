using System;

namespace FVG.FiscalAdapter.Domain.Core.Helpers
{
    public class Result
    {
        public int Success { get; set; }
        public string Error { get; set; }
        public string DocumentCancel { get; set; }
        public DocPrinter Document { get; set; }
        public Exception Exception { get; set; }

        public Result()
        {
            Success = 0;
            Error = string.Empty;
            DocumentCancel = string.Empty;
        }
    }

    public class Success : Result
    {
        public Success() : base()
        {
            Success = 1;
        }

        public Success(string documentCancel) : base()
        {
            Success = 1;
            DocumentCancel = documentCancel;
        }

        public Success(DocPrinter document) : base()
        {
            Success = 1;
            Document = document;
        }
        public Success(string documentCancel, DocPrinter document) : base()
        {
            Success = 1;
            Document = document;
            DocumentCancel = documentCancel;
        }
    }

    public class Fail : Result
    {
        public Fail(string error) : base()
        {
            Error = error;
        }

        public Fail(string documentCancel, string error) : base()
        {
            DocumentCancel = documentCancel;
            Error = error;
        }
        public Fail(string documentCancel, string error, Exception exception) : base()
        {
            DocumentCancel = documentCancel;
            Error = error;
            Exception = exception;
        }
        public Fail(string error, Exception exception) : base()
        {
            Error = error;
            Exception = exception;
        }
    }

    public class DocPrinter
    {
        public string Class { get; set; }
        public string Type { get; set; }
        public string DocNum { get; set; }
        public double TotalAmount { get; set; }
        public DateTime DocDate { get; set; }
        public string PosNum { get; set; }
    }
}