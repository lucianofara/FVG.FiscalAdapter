namespace FVG.FiscalAdapter.Domain.Entities
{
    public class CommandDocument : IEntity
    {
        public Header Header { get; set; }
        public Body Body { get; set; }
        public string[] Commands { get; set; }
    }
}