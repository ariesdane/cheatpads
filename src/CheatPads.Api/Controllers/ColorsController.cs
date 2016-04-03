using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CheatPads.Api.Controllers
{
    using CheatPads.Api.Entity.Models;
    using CheatPads.Api.Entity.Stores;

    [Authorize]
    [Route("api/[controller]")]
    public class ColorsController : Controller
    {

        private ColorStore _colorStore = new ColorStore();

        public ColorsController(ColorStore colorStore)
        {
            _colorStore = colorStore;
        }

        // GET: api/colors
        [HttpGet]
        public IEnumerable<Color> Get()
        {
            return _colorStore.Get();
        }

        // GET api/colors/5
        [HttpGet("{id}")]
        public Color Get(int id)
        {
            return _colorStore.Get(id);
        }

        // POST api/colors
        [HttpPost]
        public bool Post([FromBody]string name, string hex)
        {
            return _colorStore.Add(name, hex);
        }

        // PUT api/colors/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]string name, [FromBody]string hex)
        {
            return _colorStore.Update(id, name, hex);
        }

        // DELETE api/colors/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _colorStore.Delete(id);
        }
    }

}
