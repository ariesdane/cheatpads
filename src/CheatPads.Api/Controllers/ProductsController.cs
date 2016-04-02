using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheatPads.Api.Controllers
{
    using CheatPads.Api.Data.Stores;
    using CheatPads.Api.Data.Models;

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

            if (string.IsNullOrEmpty(item.Details)) {
                // testing extension method for merging a model with a partial model;
                item.SetValues(new {
                    Details = "<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p><p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>",
                    IgnoreMe = ":)"
                });
            }

            return item;
        }

        [HttpGet("cat/{name}")]
        public IEnumerable<Product> GetByCategoryName(string name)
        {
            return _productStore.ListByCategory(name);
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