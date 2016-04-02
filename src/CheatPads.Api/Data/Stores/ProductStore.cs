using System;
using System.Linq;
using Microsoft.Data.Entity;
using CheatPads.Api.Data.Models;

namespace CheatPads.Api.Data.Stores
{
    public class ProductStore : GenericStore<Product>
    {
        public ProductStore(ApiDbContext context) : base(context)
        {
        }
       
        public IQueryable<Product> ListByCategory(int categoryId)
        {
            return dbSet.Where(x => x.CategoryId == categoryId);
        }

        public IQueryable<Product> ListByCategory(string categoryName)
        {
            return dbSet.Where(x => x.Category.Name == categoryName);
        }
    }
}