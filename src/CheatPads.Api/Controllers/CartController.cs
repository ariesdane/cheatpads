using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CheatPads.Api.Controllers
{
    using CheatPads.Api.Entity.Models;
    using CheatPads.Api.Entity.Stores;

    //[Authorize(Policy = "TrustedClients")]
    [Route("api/[controller]")]
    public class CartController : Controller
    {

        private OrderStore _orderStore;

        public CartController(OrderStore orderStore)
        {
            _orderStore = orderStore;
        }


        // GET api/cart/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderStore.Get(id);
        }

        // POST api/cart/items
        [HttpPost("items")]
        public Order AddItem(int id, OrderItem item)
        {
            Order order = _orderStore.AddOrderItem(item);
            _orderStore.DbContext.SaveChanges();

            return order;
        }

        // DELETE api/cart/items/104
        [HttpDelete("items/{id}")]
        public Order RemoveItem(int id)
        {
            Order order = _orderStore.RemoveOrderItem(id);
            _orderStore.DbContext.SaveChanges();

            return order;
        }

    }

}
