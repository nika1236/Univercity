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
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long FacultyId { get; set; }

        public Lecturer() { }

        public Lecturer(long id, string name, string email, long faculty_id)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.FacultyId = faculty_id;
        }

        public static IEnumerable<Lecturer> GetAll()
        {
            return (LecturerDAL.GetAll());
        }

        public static Lecturer Find(long id)
        {
            return (LecturerDAL.Find(id));
        }

        public bool Create()
        {
            bool res = false;
            res = LecturerDAL.Create(this);
            return (res);
        }

        public bool Update()
        {
            return (LecturerDAL.Update(this));
        }

        public bool Delete()
        {
            return (LecturerDAL.Delete(this));
        }
    }
}
