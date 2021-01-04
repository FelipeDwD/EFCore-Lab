using System;
using System.Collections.Generic;
using Dwd.FreeProjects.OrderDrawer.ValueObjects;

namespace Dwd.FreeProjects.OrderDrawer.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public AsFreight AsFreight { get; set; }
        public OrderStatus Status { get; set; }
        public string Note { get; set; }
        public ICollection<Item> Itens { get; set; }
    }
}