using System;
using System.Linq;
using Microsoft.Data.Entity;


namespace CheatPads.Api.Entity.Stores
{
    using CheatPads.Framework.Entity;
    using CheatPads.Api.Entity.Models;

    public class CategoryStore : GenericStore<Category>
    {
        public CategoryStore(ApiDbContext context) : base(context)
        {

        }
    }
}