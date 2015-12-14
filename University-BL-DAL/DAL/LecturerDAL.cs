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
    public class LecturerDAL
    {
        private static string file = "university.db";

        public static bool CreateTable()
        {
            bool res = false;
            string query = @"CREATE TABLE IF NOT EXISTS ""Lecturer""(
                      ""id"" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                      ""name"" VARCHAR(45) NOT NULL,
                      ""email"" VARCHAR(45) NOT NULL,
                      ""faculty_id"" INTEGER NOT NULL);";

            DB db = DB.getDB(file);
            res = db.NonQuery(query);
            return (res);
        }

        public static bool Create(Lecturer e)
        {
            DB db = DB.getDB(file);
            string query = @"INSERT INTO Lecturer 
             (name, faculty_id, email)
              VALUES(@name, @faculty_id, @email)";
            Dictionary<string, object> parms =
                new Dictionary<string, object>();
            parms.Add("@name", e.Name);
            parms.Add("@email", e.Email);
            parms.Add("@faculty_id", e.FacultyId);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static ObservableCollection<Lecturer> GetAll()
        {
            ObservableCollection<Lecturer> res = new ObservableCollection<Lecturer>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Lecturer";

            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    Lecturer u = new Lecturer();
                    MappingDB2OO(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }

        public static Lecturer Find(long id)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"SELECT * FROM Lecturer WHERE id = '{0}' ", id);

            using (ISQLiteStatement statement = db.Query(query))
            {
                if (statement.Step() == SQLiteResult.ROW)
                {
                    Lecturer res = new Lecturer();
                    MappingDB2OO(statement, res);
                    return res;
                }
            }
            Lecturer empty = new Lecturer();
            return empty;
        }

        private static void MappingDB2OO(
            ISQLiteStatement statement,
            Lecturer e
            )
        {
            e.Id = (long)statement["id"];
            e.Name = (string)statement["name"];
            e.FacultyId = (long)statement["faculty_id"];
            e.Email = (string)statement["email"];
        }

        public static bool Update(Lecturer e)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"UPDATE Lecturer SET name=@name, faculty_id=@faculty_id, email=@email WHERE id='{0}'", e.Id);
            Dictionary<string, object> parms =
                new Dictionary<string, object>();

            parms.Add("@name", e.Name);
            parms.Add("@faculty_id", e.FacultyId);
            parms.Add("@email", e.Email);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (true);
        }

        public static bool Delete(Lecturer e)
        {
            DB db = DB.getDB(file);
            string query = @"DELETE FROM Lecturer WHERE id=@id";
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
