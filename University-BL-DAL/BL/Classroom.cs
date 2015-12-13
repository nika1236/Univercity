using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_BL_DAL.BL
{
    class Classroom
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public Classroom(int id, string number)
        {
            this.Id = id;
            this.Number = number;
        }
    }
}
