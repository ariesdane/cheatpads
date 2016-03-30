using System;
using System.Linq;
using Microsoft.Data.Entity;
using CheatPads.Api.Data.Models;

namespace CheatPads.Api.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(ApiDbContext context) : base(context)
        {
        }

		public IQueryable<Product> ListByCategory(int categoryId)
        {
            return dbSet.Where(x => x.CategoryId == categoryId);
        }
    }
}