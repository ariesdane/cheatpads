using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;

using CheatPads.Api.Data.Repositories;
using CheatPads.Api.Data.Models;

namespace Next.Api.Controllers
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
            return _repo.Get(sku);
            //return _dbContext.Products.FirstOrDefault(x => x.Sku == sku);
        }

        // GET api/products/sku01
        [HttpDelete("{sku}")]
        public void Delete(string sku)
        {
            _repo.Delete(sku);
            //return _dbContext.Products.FirstOrDefault(x => x.Sku == sku);
        }

        // GET api/products/sku01
        [HttpPut("{sku}")]
        public Product Put(string sku, Product product)
        {
            _repo.Update(product, sku);
            return product;
            //return _dbContext.Products.FirstOrDefault(x => x.Sku == sku);
        }

        // GET api/products/sku01
        [HttpPost()]
        public Product Post(Product product)
        {
            _repo.Create(product);
            return product;
            //return _dbContext.Products.FirstOrDefault(x => x.Sku == sku);
        }

    }
}