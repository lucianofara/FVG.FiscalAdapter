using FVG.FiscalAdapter.Domain.Entities;
using System;
using System.Linq;

namespace FVG.FiscalAdapter.Domain.Core.Validators
{
    public class CommandPrintValidator : IValidator<CommandDocument>
    {
        public void Validate(CommandDocument entity)
        {
            if (entity.Header == null)
                throw new ArgumentNullException(nameof(entity.Header));
            if (String.IsNullOrEmpty(entity.Header.Ip))
                throw new ArgumentNullException(nameof(entity.Header.Ip));
            if (entity.Header.Port == 0)
                throw new ArgumentNullException(nameof(entity.Header.Port));
            if (String.IsNullOrEmpty(entity.Header.PrinterModel))
                throw new ArgumentNullException(nameof(entity.Header.PrinterModel));
            if (entity.Commands == null)
                throw new ArgumentNullException(nameof(entity.Commands));
            if (entity.Commands.Count() == 0)
                throw new ArgumentNullException(nameof(entity.Commands));
        }
    }
}