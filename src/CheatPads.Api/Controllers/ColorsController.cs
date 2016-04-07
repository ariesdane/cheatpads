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

    //[Authorize(Policy = "TrustedClients")]
    [Route("api/[controller]")]
    public class ColorsController : Controller
    {

        private ColorStore _colorStore;

        public ColorsController(ColorStore colorStore)
        {
            _colorStore = colorStore;
        }

        // GET: api/colors
        [HttpGet]
        public IEnumerable<Color> Get()
        {
            return _colorStore.List();
        }

        // GET api/colors/5
        [HttpGet("{id}")]
        public Color Get(int id)
        {
            return _colorStore.Get(id);
        }

        // POST api/colors
        [HttpPost]
        public int Post(Color color)
        {
            var result = _colorStore.Create(color);
            _colorStore.DbContext.SaveChanges();
            return result.Id;
        }

        // PUT api/colors/5
        [HttpPut("{id}")]
        public bool Put(int id, string name, string hex)
        {
            var color = new Color() { Hex = hex, Name = name };
            return _colorStore.Update(color, id);
        }

        // DELETE api/colors/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _colorStore.Delete(id);
        }
    }

}
