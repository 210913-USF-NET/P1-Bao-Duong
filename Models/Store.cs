using System.Collections.Generic;

namespace Models
{
    public class Store
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        
        public List<Item> Item { get; set; }

        List<Item> Items { get; set; }
        
        List<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{this.Address} {this.City} {this.State}";
        }
    }
}