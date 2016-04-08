using Microsoft.Data.Entity;

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

        public new Order Get(params object[] keys)
        {
            return this.DbSet
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == (int)keys[0]);
        }

        public new bool Delete(params object[] keys)
        {
            Order order = DbSet.FirstOrDefault(x => x.Id == (int)keys[0]);
            if(order != null)
            {
                order.Status = OrderStatus.Cancelled;
                DbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Order AddOrderItem(OrderItem item)
        {
            Order order = Get(item.OrderId);
            OrderItem existingItem = null;

            if(order == null)
            {
                order = new Order();
                order.Items.Add(item);
                DbSet.Add(order);
            }
            else
            {
                existingItem = order.Items.FirstOrDefault(x =>
                    x.ProductSku == item.ProductSku && x.ColorId == item.ColorId
                );

                if (existingItem != null)
                {
                    existingItem.Quantity += item.Quantity;
                    item = existingItem;
                }
                else
                {
                    item.Product = DbContext.Set<Product>().FirstOrDefault(x => x.Sku == item.ProductSku);
                    item.Price = item.Product.Price;
                    order.Items.Add(item);
                }

                item.ExtendedCost = item.Quantity * item.Price;
            }
            return UpdateOrderCost(order);
        }

        public OrderItem RemoveOrderItem(int itemId)
        {
            OrderItem item = _itemStore.Get(itemId);

            _itemStore.DbSet.Remove(item);

            return item;
        }


        private Order UpdateOrderCost(Order order)
        {
            order.ItemCount = order.Items.Sum(x => x.Quantity);
            order.ExtendedCost = order.Items.Sum(x => x.ExtendedCost);
            order.TaxRate = 0.1;
            order.Tax = order.ExtendedCost * order.TaxRate;
            order.TotalCost = order.ExtendedCost + order.Tax + order.ShippingCost;
            
            return order;
        }
    }
}
