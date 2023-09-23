using Ramen.Controller;
using Ramen.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Repository
{
    public class RamenRepository
    {
        public static LocalDatabaseEntities db = new LocalDatabaseEntities();

        public static List<Raman> getAllRamen()
        {
            return (from x in db.Ramen select x).ToList();
        }

        public static Raman getRamenById(int id)
        {
            return (from x in db.Ramen
                    where id == x.Id
                    select x).FirstOrDefault();
        }

        public static void deleteRamen(int id)
        {
            Raman ramen = (from x in db.Ramen
                         where id == x.Id
                         select x).FirstOrDefault();
            db.Ramen.Remove(ramen);
            db.SaveChanges();

        }

        public static string addRamen(string name, int meatId, string broth, string price)
        {
            Raman newRamen = RamenFactory.createRamen(name, meatId, broth, price);

            db.Ramen.Add(newRamen);
            db.SaveChanges();

            return "SUCCESS";
        }

        public static string updateRamen(int id, string name, int meatId, string broth, string price)
        {
            Raman ramen = (from x in db.Ramen
                           where id == x.Id
                           select x).FirstOrDefault();

            bool isMeatExists = MeatController.isMeatExists(meatId);
            if (!isMeatExists)
            {
                return "UPDATE FAIL";
            }
            try
            {
                ramen.Name = name;
                ramen.MeatId = meatId;
                ramen.Broth = broth;
                ramen.Price = price;

                db.SaveChanges();
                return "SUCCESS UPDATE";
            }
            catch (Exception ex)
            {
                return "UPDATE FAIL";
            }
        }
    }
}