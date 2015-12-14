using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_BL_DAL.DAL;

namespace University_BL_DAL.BL
{
    public class Classroom
    {
        public long Id { get; set; }
        public string Number { get; set; }

        public Classroom() { }

        public Classroom(long id, string number)
        {
            this.Id = id;
            this.Number = number;
        }

        public static IEnumerable<Classroom> GetAll()
        {
            return (ClassroomDAL.GetAll());
        }

        public static Classroom Find(long id)
        {
            return (ClassroomDAL.Find(id));
        }

        public static Classroom FindByNumber(string number)
        {
            return (ClassroomDAL.FindByNumber(number));
        }

        public bool Create()
        {
            bool res = false;
            res = ClassroomDAL.Create(this);
            return (res);
        }

        public bool Update()
        {
            return (ClassroomDAL.Update(this));
        }

        public bool Delete()
        {
            return (ClassroomDAL.Delete(this));
        }
    }
}
