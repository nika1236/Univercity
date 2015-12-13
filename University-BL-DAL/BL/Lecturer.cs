using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_BL_DAL.DAL;

namespace University_BL_DAL.BL
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Faculty_id { get; set; }

        public Lecturer(int id, string name, string email, int faculty_id)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Faculty_id = faculty_id;
        }
    }
}
