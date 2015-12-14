using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAbstractionLayer;
using University_BL_DAL.BL;
using SQLitePCL;
using System.Collections.ObjectModel;

namespace University_BL_DAL.DAL
{
    public class StudentCourseDAL
    {
        private static string file = "university.db";

        public static bool CreateTable()
        {
            bool res = false;
            string query = @"CREATE TABLE IF NOT EXISTS ""StudentCourse""(
                      ""id"" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                      ""classroom_id"" INTEGER NOT NULL,
                      ""student_id"" INTEGER NOT NULL);";

            DB db = DB.getDB(file);
            res = db.NonQuery(query);
            return (res);
        }

        public static bool Create(StudentCourse e)
        {
            DB db = DB.getDB(file);
            string query = @"INSERT INTO StudentCourse 
             (classroom_id, student_id)
              VALUES(@classroom_id, @student_id)";
            Dictionary<string, object> parms =
                new Dictionary<string, object>();
            parms.Add("@classroom_id", e.ClassroomId);
            parms.Add("@student_id", e.StudentId);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static ObservableCollection<StudentCourse> GetAll()
        {
            ObservableCollection<StudentCourse> res = new ObservableCollection<StudentCourse>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM StudentCourse";

            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    StudentCourse u = new StudentCourse();
                    MappingDB2OO(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }

        public static StudentCourse Find(long id)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"SELECT * FROM StudentCourse WHERE id = '{0}' ", id);

            using (ISQLiteStatement statement = db.Query(query))
            {
                if (statement.Step() == SQLiteResult.ROW)
                {
                    StudentCourse res = new StudentCourse();
                    MappingDB2OO(statement, res);
                    return res;
                }
            }
            StudentCourse empty = new StudentCourse();
            return empty;
        }

        private static void MappingDB2OO(
            ISQLiteStatement statement,
            StudentCourse e
            )
        {
            e.Id = (long)statement["id"];
            e.ClassroomId = (long)statement["classroom_id"];
            e.StudentId = (long)statement["student_id"];
        }

        public static bool Update(StudentCourse e)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"UPDATE StudentCourse SET classroom_id=@classroom_id, student_id=@student_id WHERE id='{0}'", e.Id);
            Dictionary<string, object> parms =
                new Dictionary<string, object>();
            
            parms.Add("@classroom_id", e.ClassroomId);
            parms.Add("@student_id", e.StudentId);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (true);
        }

        public static bool Delete(StudentCourse e)
        {
            DB db = DB.getDB(file);
            string query = @"DELETE FROM StudentCourse WHERE id=@id";
            Dictionary<string, object> parms = new Dictionary<string, object>();

            parms.Add("@id", e.Id);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (true);
        }
    }
}
