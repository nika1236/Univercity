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
    public class StudentDAL
    {
        private static string file = "university.db";

        public static bool CreateTable()
        {
            bool res = false;
            string query = @"CREATE TABLE IF NOT EXISTS ""Student""(
                      ""id"" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                      ""name"" VARCHAR(45) NOT NULL,
                      ""gpa"" Float NOT NULL,
                      ""email"" VARCHAR(45) NOT NULL);";

            DB db = DB.getDB(file);
            res = db.NonQuery(query);
            return (res);
        }

        public static bool Create(Student e)
        {
            DB db = DB.getDB(file);
            string query = @"INSERT INTO Student 
             (name, gpa, email)
              VALUES(@name, @gpa, @email)";
            Dictionary<string, object> parms =
                new Dictionary<string, object>();
            parms.Add("@name", e.Name);
            parms.Add("@gpa", e.Gpa);
            parms.Add("@email", e.Email);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static ObservableCollection<Student> GetAll()
        {
            ObservableCollection<Student> res = new ObservableCollection<Student>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Student";

            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    Student u = new Student();
                    MappingDB2OO(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }

        public static Student Find(long id)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"SELECT * FROM Student WHERE id = '{0}' ", id);

            using (ISQLiteStatement statement = db.Query(query))
            {
                if (statement.Step() == SQLiteResult.ROW)
                {
                    Student res = new Student();
                    MappingDB2OO(statement, res);
                    return res;
                }
            }
            Student empty = new Student();
            return empty;
        }

        public static Student FindByName(string name)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"SELECT * FROM Student WHERE name = '{0}' ", name);

            using (ISQLiteStatement statement = db.Query(query))
            {
                if (statement.Step() == SQLiteResult.ROW)
                {
                    Student res = new Student();
                    MappingDB2OO(statement, res);
                    return res;
                }
            }
            Student empty = new Student();
            return empty;
        }

        private static void MappingDB2OO(
            ISQLiteStatement statement,
            Student e
            )
        {
            e.Id = (long)statement["id"];
            e.Name = (string)statement["name"];
            e.Gpa = (double)statement["gpa"];
            e.Email = (string)statement["email"];
        }

        public static bool Update(Student e)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"UPDATE Student SET name=@name, gpa=@gpa, email=@email WHERE id='{0}'", e.Id);
            Dictionary<string, object> parms =
                new Dictionary<string, object>();

            parms.Add("@name", e.Name);
            parms.Add("@gpa", e.Gpa);
            parms.Add("@email", e.Email);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (true);
        }

        public static bool Delete(Student e)
        {
            DB db = DB.getDB(file);
            string query = @"DELETE FROM Student WHERE id=@id";
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
