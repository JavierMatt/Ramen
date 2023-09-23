using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Repository
{
    public class MeatRepository
    {
        public static LocalDatabaseEntities db = new LocalDatabaseEntities();
        public static List<Meat> getAllMeat()
        {
            return (from x in db.Meats select x).ToList();
        }

        public static Meat getMeatById(int id)
        {
            return (from x in db.Meats where id == x.Id select x).FirstOrDefault();
        }
    }
}