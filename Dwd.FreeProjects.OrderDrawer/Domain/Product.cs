using Dwd.FreeProjects.OrderDrawer.ValueObjects;

namespace Dwd.FreeProjects.OrderDrawer.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public AsProduct AsProduct { get; set; }
        public bool Active { get; set; }
    }
}