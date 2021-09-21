using System;

namespace Models {
    public class Top
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
        public decimal Price { get; set; }

        public override string ToString() {
            return $"Name: {this.Name}, Quantity: {this.Quantity}, Price: {this.Price.ToString("C")}";
        }
    }   
}