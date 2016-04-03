using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace CheatPads.Api.Controllers
{
    using CheatPads.Api.Entity;

    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        private ApiDbContext _dbContext;

        public UsersController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/users/current
        [HttpGet, Route("current")]
        public ClaimsPrincipal  GetCurrentPrinciple()
        {
            return this.User;
        }

        [HttpGet("{id}")]
        public dynamic Get(string id)
        {
            var command = _dbContext.Database.GetDbConnection().CreateCommand();
            dynamic data = null;

            command.Connection.Open();
            command.CommandText = String.Format("SELECT * FROM [Auth].[User] WHERE Id = '{0}'", id);

            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                data = new
                {
                    Id = reader["Id"],
                    AccessFailedCount = reader["AccessFailedCount"],
                    ConcurrencyStamp = reader["ConcurrencyStamp"],
                    UserName = reader["UserName"],
                    Email = reader["Email"],
                    EmailConfirmed = reader["EmailConfirmed"],
                    LockoutEnabled = reader["LockoutEnabled"],
                    LockoutEnd = reader["LockoutEnd"],
                    PhoneNumber = reader["PhoneNumber"],
                    PhoneNumberConfirmed = reader["PhoneNumberConfirmed"],
                    SecurityStamp = reader["SecurityStamp"],
                    TwoFactorEnabled = reader["TwoFactorEnabled"],
                    DisplayName = reader["DisplayName"],
                    FirstName = reader["FirstName"],
                    LastName = reader["LastName"],
                    Gender = reader["Gender"],
                    BirthDate = reader["BirthDate"]
                };
            }
            command.Connection.Close();
            return data;
        }

        // GET: api/users
        [HttpGet, Authorize(Roles = "Administrators")]
        public IEnumerable<dynamic> Get()
        {

            //http://bitoftech.net/2015/03/11/asp-net-identity-2-1-roles-based-authorization-authentication-asp-net-web-api/
            //https://github.com/IdentityServer/IdentityServer3/issues/2240

            var command = _dbContext.Database.GetDbConnection().CreateCommand();
            var data = new List<dynamic>();

            command.Connection.Open();
            command.CommandText = "SELECT * FROM [Auth].[User]";

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new
                {
                    Id = reader["Id"],
                    UserName = reader["UserName"],
                    Email = reader["Email"],
                    EmailConfirmed = reader["EmailConfirmed"],
                    DisplayName = reader["DisplayName"],
                    FirstName = reader["FirstName"],
                    LastName = reader["LastName"],
                    Gender = reader["Gender"]
                });
            }

            command.Connection.Close();
            return data;
        }
    }
}
