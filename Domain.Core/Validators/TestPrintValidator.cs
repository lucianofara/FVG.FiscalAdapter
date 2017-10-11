using FVG.FiscalAdapter.Domain.Entities;
using System;

namespace FVG.FiscalAdapter.Domain.Core.Validators
{
    public class TestPrintValidator : IValidator<TestDocument>
    {
        public void Validate(TestDocument entity)
        {
            if (entity.Header == null)
                throw new ArgumentNullException(nameof(entity.Header));
            if (String.IsNullOrEmpty(entity.Header.Ip))
                throw new ArgumentNullException(nameof(entity.Header.Ip));
            if (entity.Header.Port == 0)
                throw new ArgumentNullException(nameof(entity.Header.Port));
            if (String.IsNullOrEmpty(entity.Header.PrinterModel))
                throw new ArgumentNullException(nameof(entity.Header.PrinterModel));
        }
    }
}