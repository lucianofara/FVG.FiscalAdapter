namespace FVG.FiscalAdapter.Domain.Entities
{
    public class Items : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double Iva { get; set; }
        public double Quantity { get; set; }
    }
}