using Ramen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Handler
{
    public class RamenHandler
    {
        public static List<Raman> getAllRamen()
        {
            return RamenRepository.getAllRamen();
        }

        public static Raman getRamenById(int id)
        {
            return RamenRepository.getRamenById(id);
        }

        public static void deleteRamen(int id)
        {
            RamenRepository.deleteRamen(id);
        }

        public static string addRamen(string name, int meatId, string broth, string price )
        {
            return RamenRepository.addRamen(name, meatId, broth, price);
        }

        public static string updateRamen(int id, string name, int meatId, string broth, string price)
        {
            return RamenRepository.updateRamen(id, name, meatId, broth, price);
        }


    }
}