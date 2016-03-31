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

        public new IQueryable<Product> List()
        {
            return dbSet.Include(x => x.Category);
        }

        public Product Get(string sku)
        {
            return dbSet.Where(x => x.Sku == sku).Include(x => x.Category).FirstOrDefault();
        }

        public IQueryable<Product> ListByCategory(int categoryId)
        {
            return dbSet.Where(x => x.CategoryId == categoryId).Include(x => x.Category);
        }
    }
}