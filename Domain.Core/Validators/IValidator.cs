namespace FVG.FiscalAdapter.Domain.Core.Validators
{
    public interface IValidator<TEntity>
    {
        void Validate(TEntity entity);
    }
}