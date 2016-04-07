using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
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
    public class OrdersController : Controller
    {

        private OrderStore _orderStore;

        public OrdersController(OrderStore orderStore)
        {
            _orderStore = orderStore;
        }

        // GET: api/orders
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderStore.List();
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderStore.Get(id);
        }

        // POST api/orders
        [HttpPost]
        public int Post(Order order)
        {
            var result = _orderStore.Create(order);
            _orderStore.DbContext.SaveChanges();

            return result.Id;
        }

        // POST api/orders/5/items
        [HttpPost("{id}/items")]
        public int AddItem(int id, OrderItem item)
        {
            var result = _orderStore.AddItem(item, id);
            _orderStore.DbContext.SaveChanges();

            return result.Id;
        }


        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _orderStore.Delete(id);
        }
    }

}
