using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Api.Entity.Models
{
    public class Order
    {

        public Order()
        {
            this.Items = new List<OrderItem>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public int ItemCount { get; set; }

        public double ExtendedCost { get; set; }

        public ShippingMethod ShippingMethod { get; set; } = ShippingMethod.Standard;

        public double ShippingCost { get; set; }

        public double TaxRate { get; set; }

        public double Tax { get; set; }

        public double TotalCost { get; set; }

        public PaymentType PaymentType { get; set; } = PaymentType.CreditCard;

        public string PaymentAccount { get; set; }

        public string ZipCode { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.InCart;

        public DateTime ShippedOn { get; set; }

        public string TrackingNumber { get; set; }

        public virtual List<OrderItem> Items { get; set; }
    }
}
