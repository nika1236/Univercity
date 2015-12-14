using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_BL_DAL.BL;
using SQLitePCL;

namespace University
{
    class Program
    {
        static void Main(string[] args)
        {
            //create tables
            Database.CreateTables();

            //create individual records
            Faculty faculty = new Faculty(1, "programming");
            faculty.Create();

            Lecturer lecturer = new Lecturer(1, "Jose", "exp@ipb.pt", faculty.Id);
            lecturer.Create();

            Classroom classroom = new Classroom(1, "123");
            classroom.Create();

            Student student = new Student(1, "Nikoloz Kavtaradze", 81.5, "nikolozkavtaradze@gmail.com");
            student.Create();

            Course course = new Course(1, "Application Development", faculty.Id, lecturer.Id);
            course.Create();

            StudentCourse lecture = new StudentCourse(1, classroom.Id, student.Id);
            lecture.Create();

            //update
            student.Gpa = 90;
            student.Update();

            //find by id
            Console.WriteLine(Course.Find(course.Id).Name);

            //Demonstrate find by two ids
            StudentCourse student_course = StudentCourse.FindByClassroomIdAndStudentId(classroom.Id, student.Id);

            //clean the records
            faculty.Delete();
            lecturer.Delete();
            classroom.Delete();
            student.Delete();
            course.Delete();
            lecture.Delete();

            Console.ReadKey();
        }
    }
}
