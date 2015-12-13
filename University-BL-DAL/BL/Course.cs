using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_BL_DAL.DAL;

namespace University_BL_DAL.BL
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public int LecturerId { get; set; }

        public Course(int id, string name, int faculty_id, int lecturer_id)
        {
            this.Id = id;
            this.Name = name;
            this.FacultyId = faculty_id;
            this.LecturerId = lecturer_id;
        }
    }
}
