using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_BL_DAL.DAL;

namespace University_BL_DAL.BL
{
    public class StudentCourse
    {
        public long Id { get; set; }
        public long ClassroomId { get; set; }
        public long StudentId { get; set; }

        public StudentCourse() { }

        public StudentCourse(long id, long classroom_id, long student_id)
        {
            this.Id = id;
            this.ClassroomId = classroom_id;
            this.StudentId = student_id;
        }

        public static IEnumerable<StudentCourse> GetAll()
        {
            return (StudentCourseDAL.GetAll());
        }

        public static StudentCourse Find(long id)
        {
            return (StudentCourseDAL.Find(id));
        }

        public bool Create()
        {
            bool res = false;
            res = StudentCourseDAL.Create(this);
            return (res);
        }

        public bool Update()
        {
            return (StudentCourseDAL.Update(this));
        }

        public bool Delete()
        {
            return (StudentCourseDAL.Delete(this));
        }
    }
}
