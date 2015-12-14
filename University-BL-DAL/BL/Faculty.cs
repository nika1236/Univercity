using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_BL_DAL.DAL;

namespace University_BL_DAL.BL
{
    public class Faculty
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Faculty() { }

        public Faculty(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public static IEnumerable<Faculty> GetAll()
        {
            return (FacultyDAL.GetAll());
        }

        public static Faculty Find(long id)
        {
            return (FacultyDAL.Find(id));
        }

        public static Faculty FindByName(string name)
        {
            return (FacultyDAL.FindByName(name));
        }

        public bool Create()
        {
            bool res = false;
            res = FacultyDAL.Create(this);
            return (res);
        }

        public bool Update()
        {
            return (FacultyDAL.Update(this));
        }

        public bool Delete()
        {
            return (FacultyDAL.Delete(this));
        }
    }
}
