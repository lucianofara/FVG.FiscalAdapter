using System.Collections.Generic;

namespace FVG.FiscalAdapter.Domain.Entities
{
    public class Body : IEntity
    {
        public string Comprobante { get; set; }
        public string TipoComprobante { get; set; }
        public string Customer { get; set; }
        public string Dni { get; set; }
        public IEnumerable<Items> Items { get; set; }
    }
}