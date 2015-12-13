using SQLitePCL;
using System;
using System.Collections.Generic;

namespace DataAbstractionLayer
{
    public class DB : IDisposable
    {
        private bool isDisposed=false;

        private SQLiteConnection conn;

        private static DB db = null;

        private DB(string file)
        {
            conn = new SQLiteConnection(file);

        }

        public static DB getDB(string file) {
            if (db == null)
            {
                db=new DB(file);
            }
            return (db);
        }

        public ISQLiteStatement Query(string query,
            Dictionary<string, object> parms = null)
        {
            ISQLiteStatement statement = this.conn.Prepare(query);

            if (parms != null)
            {
                foreach (KeyValuePair<string, object> p in parms)
                {
                    statement.Bind(p.Key, p.Value);
                }
            }

            return (statement);
        }

        public bool NonQuery(string query, 
            Dictionary<string, object> parms=null)
        {
            bool res = false;
            using (ISQLiteStatement statement = this.conn.Prepare(query))

            {
                if (parms != null)
                {
                    foreach (KeyValuePair<string, object> p in parms)
                    {
                        statement.Bind(p.Key, p.Value);
                    }
                }

                res = statement.Step() == SQLiteResult.DONE;
            }


            return (res);
        }

        public long LastId()
        {
            long res = conn.LastInsertRowId();
            return (res);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);   
        }

        ~DB()
        {
            Dispose(false);
        }

        protected void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing)
            {
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
            conn = null;
            isDisposed = true;
        }
    }
}
