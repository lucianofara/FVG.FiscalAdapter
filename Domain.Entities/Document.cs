namespace FVG.FiscalAdapter.Domain.Entities
{
    public class Document : IEntity
    {
        public Header Header { get; set; }
        public Body Body { get; set; }
    }
}