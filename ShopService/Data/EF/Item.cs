using System;
using System.Collections.Generic;

#nullable disable

namespace ShopService.Data.EF
{
    public partial class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Typeid { get; set; }
        public long Quantity { get; set; }
        public decimal Baseprice { get; set; }

        public virtual Itemtype Type { get; set; }
    }
}
