using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Api.Data.Stores
{
    using CheatPads.Api.Data.Models;

    public class ColorStore
    {
        private List<Color> _colors;

        public ColorStore()
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
            if (!_colors.Exists(x => x.Name.ToLower() == name.ToLower()))
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
            if (_colors.Exists(x => x.Id == id))
            {
                var color = this.Get(id);
                return _colors.Remove(color);
            }
            return false;
        }
    }
}
