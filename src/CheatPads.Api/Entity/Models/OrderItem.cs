using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Api.Entity.Models
{
    public class OrderItem 
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string ProductSku { get; set; }

        public int ColorId { get; set; }

        public int Quantity { get; set; }

        public double ExtendedCost { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public virtual Color Color { get; set; }
    }
}
