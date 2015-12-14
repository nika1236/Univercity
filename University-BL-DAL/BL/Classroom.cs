using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_BL_DAL.DAL;

namespace University_BL_DAL.BL
{
    public class Classroom
    {
        public long Id { get; set; }
        public string Number { get; set; }

        public Classroom() { }

        public Classroom(long id, string number)
        {
            this.Id = id;
            this.Number = number;
        }
    }
}
