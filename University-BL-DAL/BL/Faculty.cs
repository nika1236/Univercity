using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_BL_DAL.BL
{
    class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Faculty(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
