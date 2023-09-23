using Ramen.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Controller
{
    public class MeatController
    {
        public static List<Meat> getAllMeat()
        {
            return MeatHandler.getAllMeat();
        }

        public static bool isMeatExists(int id)
        {
            return MeatHandler.isMeatExists(id);
        }

        public static string getMeatName(int id)
        {
            return MeatHandler.getMeatName(id);
        }
    }
}