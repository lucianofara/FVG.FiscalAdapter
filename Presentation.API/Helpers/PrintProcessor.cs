using Autofac;
using FVG.FiscalAdapter.Domain.Core.Helpers;
using FVG.FiscalAdapter.Domain.Core.Printer;
using FVG.FiscalAdapter.Domain.Entities;

namespace FVG.FiscalAdapter.Presentation.API.Helpers
{
    public class PrintProcessor : IPrintProcessor
    {
        private readonly ILifetimeScope container;

        public PrintProcessor(ILifetimeScope container)
        {
            this.container = container;
        }

        public Result Print<TEntity>(TEntity document) where TEntity : IEntity
        {
            var handler = container.Resolve<IPrintHandler<TEntity>>();
            return handler.Print(document);
        }
    }
}