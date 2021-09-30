using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Store
    {
        public Store()
        {
            Items = new HashSet<Item>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
