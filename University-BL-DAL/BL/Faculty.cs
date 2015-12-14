using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_BL_DAL.DAL;

namespace University_BL_DAL.BL
{
    public class Faculty
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Faculty() { }

        public Faculty(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
