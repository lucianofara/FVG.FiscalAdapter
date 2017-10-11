namespace FVG.FiscalAdapter.Domain.Entities
{
    public class Header : IEntity
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        public string Channel { get; set; }
        public string Registry { get; set; }
        public string PrinterName { get; set; }
        public string PrinterModel { get; set; }
    }
}