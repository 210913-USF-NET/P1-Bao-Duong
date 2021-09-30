using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Size
    {
        public int Id { get; set; }
        public string ClothingSize { get; set; }
        public int? SizeQuantity { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
