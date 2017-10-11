using FVG.FiscalAdapter.Domain.Core.Helpers;
using FVG.FiscalAdapter.Domain.Core.Logger;
using FVG.FiscalAdapter.Domain.Core.Printer;

namespace FVG.FiscalAdapter.Domain.Core.Decorators
{
    public class LoggerEntityHandlerDecorator<TEntity> : IPrintHandler<TEntity>
    {
        private readonly IPrintHandler<TEntity> _decorated;
        private readonly ILog _logger;

        public LoggerEntityHandlerDecorator(IPrintHandler<TEntity> decorated, ILog logger)
        {
            _decorated = decorated;
            _logger = logger;
        }

        public Result Print(TEntity document)
        {
            _logger.Info("Inicio de llamada", null);
            var result = _decorated.Print(document);
            _logger.Info("Fin de llamada", null);
            return result;
        }
    }
}