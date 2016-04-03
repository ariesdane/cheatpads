using System;
using System.Linq;
using Microsoft.Data.Entity;
using CheatPads.Api.Entity.Models;

namespace CheatPads.Api.Entity.Stores
{
    public class CategoryStore : GenericStore<Category>
    {
        public CategoryStore(ApiDbContext context) : base(context)
        {

        }
    }
}