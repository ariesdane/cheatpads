using System;
using System.Collections.Generic;

namespace CheatPads.Api.Entity.Models
{
    public class Color
    {
        public int Id { get; set; }

        public string Hex { get; set; }

        public string Name { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
