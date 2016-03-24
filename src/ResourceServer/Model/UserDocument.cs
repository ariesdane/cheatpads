using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5SQLite.Model
{
    public class UserDocument
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public string Extention { get; set; }
        public string Title { get; set; }
        public int Size { get; set; }
        public  DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

    }
}
