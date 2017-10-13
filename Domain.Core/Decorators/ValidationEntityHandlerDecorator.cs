using FVG.FiscalAdapter.Domain.Core.Helpers;
using FVG.FiscalAdapter.Domain.Core.Printer;
using FVG.FiscalAdapter.Domain.Core.Validators;
using System;

namespace FVG.FiscalAdapter.Domain.Core.Decorators
{
    public sealed class ValidationEntityHandlerDecorator<TEntity> : IPrintHandler<TEntity>
    {
        private readonly IPrintHandler<TEntity> decorated;
        private readonly IValidator<TEntity> validator;

        public ValidationEntityHandlerDecorator(IPrintHandler<TEntity> decorated, IValidator<TEntity> validator)
        {
            this.decorated = decorated;
            this.validator = validator;
        }

        Result IPrintHandler<TEntity>.Print(TEntity document)
        {
            try
            {
                this.validator.Validate(document);
            }
            catch (Exception ex)
            {
                return new Fail(ex.Message,ex);
            }

            return this.decorated.Print(document);
        }
    }
}