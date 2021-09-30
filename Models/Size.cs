using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Size
    {
        public int Id { get; set; }
        
        public string ClothingSize { get; set; }

        public int SizeQuantity { get; set; }
        
        public int ItemId { get; set; }

        public override string ToString()
        {
            return $"Size: {this.ClothingSize} Quantity: {this.SizeQuantity}";
        }
    }
}