using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace CheatPads.Api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        public UsersController()
        {

        }

        // GET: api/users/current
        [HttpGet, Route("current")]
        public ClaimsPrincipal  GetCurrentPrinciple()
        {
            return this.User;
        }
    }
}
