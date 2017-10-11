using FVG.FiscalAdapter.Domain.Core.Helpers;

namespace FVG.FiscalAdapter.Domain.Core.Printer
{
    public interface IPrintHandler<TEntity>
    {
        Result Print(TEntity document);
    }
}