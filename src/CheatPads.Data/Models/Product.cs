using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Data.Models
{
    public class Product
    {
        public string Sku { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
