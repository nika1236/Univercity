using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAbstractionLayer;
using University_BL_DAL.BL;
using System.Collections.ObjectModel;
using SQLitePCL;

namespace University_BL_DAL.DAL
{
    public class CourseDAL
    {
        private static string file = "university.db";

        public static bool CreateTable()
        {
            bool res = false;
            string query = @"CREATE TABLE IF NOT EXISTS ""Course""(
                      ""id"" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                      ""name"" VARCHAR(45) NOT NULL,
                      ""faculty_id"" INTEGER NOT NULL,
                      ""lecturer_id"" INTEGER NOT NULL);";

            DB db = DB.getDB(file);
            res = db.NonQuery(query);
            return (res);
        }

        public static bool Create(Course e)
        {
            DB db = DB.getDB(file);
            string query = @"INSERT INTO Course 
             (name, faculty_id, lecturer_id)
              VALUES(@name, @faculty_id, @lecturer_id)";
            Dictionary<string, object> parms =
                new Dictionary<string, object>();
            parms.Add("@name", e.Name);
            parms.Add("@faculty_id", e.FacultyId);
            parms.Add("@lecturer_id", e.LecturerId);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static ObservableCollection<Course> GetAll()
        {
            ObservableCollection<Course> res = new ObservableCollection<Course>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Course";

            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    Course u = new Course();
                    MappingDB2OO(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }

        public static Course Find(long id)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"SELECT * FROM Course WHERE id = '{0}' ", id);

            using (ISQLiteStatement statement = db.Query(query))
            {
                if (statement.Step() == SQLiteResult.ROW)
                {
                    Course res = new Course();
                    MappingDB2OO(statement, res);
                    return res;
                }
            }
            Course empty = new Course();
            return empty;
        }

        private static void MappingDB2OO(
            ISQLiteStatement statement,
            Course e
            )
        {
            e.Id = (long)statement["id"];
            e.Name = (string)statement["name"];
            e.FacultyId = (long)statement["faculty_id"];
            e.LecturerId = (long)statement["lecturer_id"];
        }

        public static bool Update(Course e)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"UPDATE Course SET name=@name, faculty_id=@faculty_id, lecturer_id=@lecturer_id WHERE id='{0}'", e.Id);
            Dictionary<string, object> parms =
                new Dictionary<string, object>();

            parms.Add("@name", e.Name);
            parms.Add("@faculty_id", e.FacultyId);
            parms.Add("@lecturer_id", e.LecturerId);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (true);
        }

        public static bool Delete(Course e)
        {
            DB db = DB.getDB(file);
            string query = @"DELETE FROM Course WHERE id=@id";
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
