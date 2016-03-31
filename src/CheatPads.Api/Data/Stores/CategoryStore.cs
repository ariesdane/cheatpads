using System;
using System.Linq;
using Microsoft.Data.Entity;
using CheatPads.Api.Data.Models;

namespace CheatPads.Api.Data.Stores
{
    public class CategoryStore : GenericStore<Category>
    {
        public CategoryStore(ApiDbContext context) : base(context)
        {

        }
    }
}