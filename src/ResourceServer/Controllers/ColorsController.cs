using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Next.Api.Controllers
{
    [Route("api/[controller]")]
    public class ColorsController : Controller
    {

        private ColorsDB _colorsDB = new ColorsDB();

        // GET: api/colors
        [HttpGet]
        public IEnumerable<Color> Get()
        {
            return _colorsDB.Get();
        }

        // GET api/colors/5
        [HttpGet("{id}")]
        public Color Get(int id)
        {
            return _colorsDB.Get(id);
        }

        // POST api/colors
        [HttpPost]
        public bool Post([FromBody]string name, string hex)
        {
            return _colorsDB.Add(name, hex);
        }

        // PUT api/colors/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]string name, [FromBody]string hex)
        {
            return _colorsDB.Update(id, name, hex);
        }

        // DELETE api/colors/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _colorsDB.Delete(id);
        }
    }

    public class Color
    {
        public int Id { get; set; }
        public string Hex { get; set; }
        public string Name { get; set; }
    }

    public class ColorsDB 
    {
        private List<Color> _colors;

        public ColorsDB()
        {
            _colors = new List<Color>()
            {
                new Color() { Id = 1, Name="White", Hex = "#FFFFFF" },
                new Color() { Id = 2, Name="Black", Hex = "#000000" },
                new Color() { Id = 3, Name="Gray", Hex = "#F0F0F0" },
                new Color() { Id = 4, Name="Red", Hex = "#FF0000" },
                new Color() { Id = 5, Name="Green", Hex = "#00FF00" },
                new Color() { Id = 6, Name="Blue", Hex = "#0000FF" },
                new Color() { Id = 7, Name="Purple", Hex = "#FF00FF" },
            };
        }

      
        public List<Color> Get()
        {
            return _colors;
        }

        public Color Get(int id)
        {
            return _colors.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(string name, string hex)
        {
            if(!_colors.Exists(x => x.Name.ToLower() == name.ToLower()))
            {
                var id = _colors.Max(x => x.Id) + 1;
                _colors.Add(new Color() { Id = id, Name = name, Hex = hex });
            }
            return false;
        }

        public bool Update(int id, string name, string hex)
        {
            if (_colors.Exists(x => x.Id == id))
            {
                var color = this.Get(id);

                color.Name = name;
                color.Hex = hex;

                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            if(_colors.Exists(x => x.Id == id))
            {
                var color = this.Get(id);
                return _colors.Remove(color);
            }
            return false;
        }
    }
}
