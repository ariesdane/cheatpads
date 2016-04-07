using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Api.Entity.Models
{
    public class Order
    {

        public int Id { get; set; }
              
        public string UserId { get; set; }

        public double ProductCost { get; set; }

        public double ShippingCost { get; set; }

        public double Tax { get; set; }

        public double TotalCost { get; set; }

        public string ZipCode { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public OrderStatus Status { get; set;}

        public DateTime ShippedOn { get; set; }

        public string TrackingNumber { get; set; }

        public virtual List<OrderItem> Items { get; set; }
    }
}
