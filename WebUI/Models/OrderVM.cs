﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class OrderVM
    {
        public string Username { get; set; }

        public string Item { get; set; }

        public decimal Price { get; set; }

        public string Size { get; set; }

        public int Quantity { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
