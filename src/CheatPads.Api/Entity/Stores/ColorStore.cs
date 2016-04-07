using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Api.Entity.Stores
{
    using CheatPads.Api.Entity.Models;
    using CheatPads.Framework.Entity;

    public class ColorStore : GenericStore<Color>
    {
        public ColorStore(ApiDbContext context) : base(context)
        {
           
        }
    }
}
