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
    public class ClassroomDAL
    {
        private static string file = "university.db";

        public static bool CreateTable()
        {
            bool res = false;
            string query = @"CREATE TABLE IF NOT EXISTS ""Classroom""(
                      ""id"" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                      ""number"" VARCHAR(45) NOT NULL);";

            DB db = DB.getDB(file);
            res = db.NonQuery(query);
            return (res);
        }

        public static bool Create(Classroom e)
        {
            DB db = DB.getDB(file);
            string query = @"INSERT INTO Classroom 
             (number)
              VALUES(@number)";
            Dictionary<string, object> parms =
                new Dictionary<string, object>();
            parms.Add("@number", e.Number);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static ObservableCollection<Classroom> GetAll()
        {
            ObservableCollection<Classroom> res = new ObservableCollection<Classroom>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Classroom";

            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    Classroom u = new Classroom();
                    MappingDB2OO(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }

        public static Classroom Find(long id)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"SELECT * FROM Classroom WHERE id = '{0}' ", id);

            using (ISQLiteStatement statement = db.Query(query))
            {
                if (statement.Step() == SQLiteResult.ROW)
                {
                    Classroom res = new Classroom();
                    MappingDB2OO(statement, res);
                    return res;
                }
            }
            Classroom empty = new Classroom();
            return empty;
        }

        private static void MappingDB2OO(
            ISQLiteStatement statement,
            Classroom e
            )
        {
            e.Id = (long)statement["id"];
            e.Number = (string)statement["number"];
        }

        public static bool Update(Classroom e)
        {
            DB db = DB.getDB(file);
            string query = string.Format(@"UPDATE Classroom SET number=@number WHERE id='{0}'", e.Id);
            Dictionary<string, object> parms =
                new Dictionary<string, object>();

            parms.Add("@number", e.Number);

            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (true);
        }

        public static bool Delete(Classroom e)
        {
            DB db = DB.getDB(file);
            string query = @"DELETE FROM Classroom WHERE id=@id";
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
