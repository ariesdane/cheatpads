using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheatPads.Api.Controllers
{
    using CheatPads.Api.Data.Stores;
    using CheatPads.Api.Data.Models;

    [Authorize]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private ProductStore _productStore;

        public ProductsController(ProductStore productStore)
        {
            _productStore = productStore;
        }

        // GET: api/products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productStore.List();
        }

        // GET api/products/sku01
        [HttpGet("{sku}")]
        public Product  Get(string sku)
        {
            var item = _productStore.Get(sku);

            if (string.IsNullOrEmpty(item.Description)) {
                // testing extension method for merging a model with a partial model;
                item.SetValues(new { Description = "This is the best product ever", IgnoreMe = ":)" });
            }

            return item;
        }

        // DELETE api/products/sku01
        [HttpDelete("{sku}")]
        public void Delete(string sku)
        {
            _productStore.Delete(sku);
        }

        // PUT api/products/sku01
        [HttpPut("{sku}")]
        public Product Put(string sku, Product product)
        {
            _productStore.Update(product, sku);
            return product;
        }

        // POST api/products/sku01
        [HttpPost()]
        public Product Post(Product product)
        {
            _productStore.Create(product);
            return product;
        }

    }
}