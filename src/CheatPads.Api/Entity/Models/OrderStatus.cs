using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Api.Entity.Models
{
    public enum OrderStatus
    {
        Cancelled = -2,
        Refunded = -1,
        InCart = 0,
        Ordered = 1,
        Shipped = 5,
        Fulfilled = 7
    }
}
