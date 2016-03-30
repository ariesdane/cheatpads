using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;

using CheatPads.Api.Data;
using CheatPads.Api.Data.Models;

namespace Next.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private ApiDbContext  _dbContext;

        public ProductsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.EnsureDbExists();
        }

        // GET: api/products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _dbContext.Products.ToList();
        }

        // GET api/products/sku01
        [HttpGet("{sku}")]
        public Product  Get(string sku)
        {
            return _dbContext.Products.FirstOrDefault(x => x.Sku == sku);
        }

    }
}