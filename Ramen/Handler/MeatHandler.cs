using Ramen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Handler
{
    public class MeatHandler
    {
        public static List<Meat> getAllMeat()
        {
            return MeatRepository.getAllMeat();
        }

        public static bool isMeatExists(int id)
        {
            if(MeatRepository.getMeatById(id) != null)
            {
                return true;
            }
            return false;
        }

        public static string getMeatName(int id)
        {
            return (MeatRepository.getMeatById(id).Name);
        }
    }
}