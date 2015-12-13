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
        public int Id { get; set; }
        public string Name { get; set; }
        public double Gpa { get; set; }
        public string Email { get; set; }

        public Student(int id, string name, double gpa, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Gpa = gpa;
            this.Email = email;
        }
    }
}
