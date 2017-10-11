namespace FVG.FiscalAdapter.Domain.Entities
{
    public class OpenCommandDocument : IEntity
    {
        public Header Header { get; set; }
        public Body Body { get; set; }
        public string[] Commands { get; set; }
    }
}