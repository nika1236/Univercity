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
    public class FacultyDAL
    {
        private static string file = "university.db";

        public static bool CreateTable()
        {
            bool res = false;
            string query = @"CREATE TABLE IF NOT EXISTS ""Faculty""(
                      ""id"" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                      ""name"" VARCHAR(45) NOT NULL);";

            DB db = DB.getDB(file);
            res = db.NonQuery(query);
            return (res);
        }

        public static bool Create(Faculty e)
        {
            DB db = DB.getDB(file);
            string query = @"INSERT INTO Faculty 
             (name)
              VALUES(@name)";
            Dictionary<string, object> parms =
                new Dictionary<string, object>();
            parms.Add("@name", e.Name);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static ObservableCollection<Faculty> GetAll()
        {
            ObservableCollection<Faculty> res = new ObservableCollection<Faculty>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Faculty";

            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    Faculty u = new Faculty();
                    MappingDB2OO(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }

        public static Faculty Find(long id)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"SELECT * FROM Faculty WHERE id = '{0}' ", id);

            using (ISQLiteStatement statement = db.Query(query))
            {
                if (statement.Step() == SQLiteResult.ROW)
                {
                    Faculty res = new Faculty();
                    MappingDB2OO(statement, res);
                    return res;
                }
            }
            Faculty empty = new Faculty();
            return empty;
        }

        public static Faculty FindByName(string name)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"SELECT * FROM Faculty WHERE name = '{0}' ", name);

            using (ISQLiteStatement statement = db.Query(query))
            {
                if (statement.Step() == SQLiteResult.ROW)
                {
                    Faculty res = new Faculty();
                    MappingDB2OO(statement, res);
                    return res;
                }
            }
            Faculty empty = new Faculty();
            return empty;
        }

        private static void MappingDB2OO(
            ISQLiteStatement statement,
            Faculty e
            )
        {
            e.Id = (long)statement["id"];
            e.Name = (string)statement["name"];
        }

        public static bool Update(Faculty e)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"UPDATE Faculty SET name=@name WHERE id='{0}'", e.Id);
            Dictionary<string, object> parms =
                new Dictionary<string, object>();

            parms.Add("@name", e.Name);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (true);
        }

        public static bool Delete(Faculty e)
        {
            DB db = DB.getDB(file);
            string query = @"DELETE FROM Faculty WHERE id=@id";
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
