using System;
using System.Collections.Generic;

#nullable disable

namespace ShopService.Data.EF
{
    public partial class Itemtype
    {
        public Itemtype()
        {
            Items = new HashSet<Item>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
