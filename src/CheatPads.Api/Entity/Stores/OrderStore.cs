using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Api.Entity.Stores
{
    using CheatPads.Api.Entity.Models;
    using CheatPads.Framework.Entity;
    using CheatPads.Framework.Extensions;

    public class OrderStore : GenericStore<Order>
    {
        private GenericStore<OrderItem> _itemStore;

        public OrderStore(ApiDbContext context) : base(context)
        {
            _itemStore = new GenericStore<OrderItem>(context);
        }


        public Order AddItem(OrderItem item, params object[] keys)
        {
            var order = Get(keys);
            var orderItem = _itemStore.DbSet.FirstOrDefault(x =>
                x.OrderId == order.Id && x.ProductSku == item.ProductSku && x.ColorId == item.ColorId
            );

            if(order == null)
            {
                order = new Order();
                DbSet.Add(order);
            }

            if(orderItem == null)
            {
                orderItem = item;
            }
            else
            {
                item.Quantity = orderItem.Quantity += 1;
                orderItem.SetValues(item);
            }

            order.Items.Add(orderItem);

            return order;
        }
    }
}
