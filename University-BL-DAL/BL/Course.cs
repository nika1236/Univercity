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
        public long Id { get; set; }
        public string Name { get; set; }
        public long FacultyId { get; set; }
        public long LecturerId { get; set; }

        public Course() { }

        public Course(long id, string name, long faculty_id, long lecturer_id)
        {
            this.Id = id;
            this.Name = name;
            this.FacultyId = faculty_id;
            this.LecturerId = lecturer_id;
        }
    }
}
