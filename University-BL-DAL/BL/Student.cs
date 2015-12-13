using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_BL_DAL.BL
{
    class Student
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
