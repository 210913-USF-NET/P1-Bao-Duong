using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int StoreId { get; set; }

        public Customer Customers { get; set; }

        public Store Stores { get; set; }

        public override string ToString()
        {
            return $"Order_Id: {this.Id} Customer_Id {this.CustomerId} Store_Id {this.StoreId}";
        }
    }
}