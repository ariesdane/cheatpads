namespace CheatPads.Api.Controllers
{
    using System.Collections.Generic;

    using CheatPads.Api.Model;
    using CheatPads.Api.Repositories;

    using Microsoft.AspNet.Authorization;
    using Microsoft.AspNet.Mvc;

    [Authorize]
    [Route("api/[controller]")]
    public class UserEventsController : Controller
    {
        private readonly IRepository<UserEvent> _repo;

        public UserEventsController(IRepository<UserEvent> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IEnumerable<UserEvent> Get()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}")]
        public UserEvent Get(long id)
        {
            return _repo.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]UserEvent value)
        {
            _repo.Post(value);
        }

        [HttpPut("{id}")]
        public void Put(long id, [FromBody]UserEvent value)
        {
            _repo.Put(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _repo.Delete(id);
        }
    }
}
