using FVG.FiscalAdapter.Domain.Core.Helpers;
using FVG.FiscalAdapter.Domain.Entities;

namespace FVG.FiscalAdapter.Presentation.API.Helpers
{
    public interface IPrintProcessor
    {
        Result Print<TEntity>(TEntity document) where TEntity : IEntity;
    }
}