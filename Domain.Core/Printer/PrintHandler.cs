using FVG.FiscalAdapter.Domain.Core.Helpers;
using FVG.FiscalAdapter.Domain.Entities;
using System;

namespace FVG.FiscalAdapter.Domain.Core.Printer
{
    public class PrintHandler : _FiscalHandler, IPrintHandler<Document>
    {
        public Result Print(Document document)
        {
            throw new NotImplementedException();
        }
    }
}