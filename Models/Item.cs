using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int SizeTotal { get; set; }

        public List<Size> Size { get; set; }

        public override string ToString()
        {
            return $"{this.Name} Price: {this.Price.ToString("C")}";
        }
    }
}