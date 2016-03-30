using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;

using CheatPads.Api.Data.Repositories;
using CheatPads.Api.Data.Models;

namespace CheatPads.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private ProductRepository _repo;

        public ProductsController(ProductRepository repo)
        {
            _repo = repo;
        }

        // GET: api/products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repo.List();
        }

        // GET api/products/sku01
        [HttpGet("{sku}")]
        public Product  Get(string sku)
        {
            var item = _repo.Get(sku);

            if (string.IsNullOrEmpty(item.Description)) {
                // testing extension method for merging a model with a partial model;
                item.SetValues(new { Description = "This is the best product ever", IgnoreMe = ":)" });
            }

            return item;
        }

        // GET api/products/sku01
        [HttpDelete("{sku}")]
        public void Delete(string sku)
        {
            _repo.Delete(sku);
        }

        // GET api/products/sku01
        [HttpPut("{sku}")]
        public Product Put(string sku, Product product)
        {
            _repo.Update(product, sku);
            return product;
        }

        // GET api/products/sku01
        [HttpPost()]
        public Product Post(Product product)
        {
            _repo.Create(product);
            return product;
        }

    }
}