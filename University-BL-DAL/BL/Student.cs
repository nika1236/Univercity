using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_BL_DAL.DAL;

namespace University_BL_DAL.BL
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Gpa { get; set; }
        public string Email { get; set; }

        public Student() { }

        public Student(long id, string name, double gpa, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Gpa = gpa;
            this.Email = email;
        }

        public static IEnumerable<Student> GetAll()
        {
            return (StudentDAL.GetAll());
        }

        public static Student Find(long id)
        {
            return (StudentDAL.Find(id));
        }

        public bool Create()
        {
            bool res = false;
            res = StudentDAL.Create(this);
            return (res);
        }

        public bool Update()
        {
            return (StudentDAL.Update(this));
        }

        public bool Delete()
        {
            return (StudentDAL.Delete(this));
        }
    }
}
