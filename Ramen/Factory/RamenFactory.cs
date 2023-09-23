using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Factory
{
    public class RamenFactory
    {
        public static Raman createRamen(string name, int meatId, string broth, string price)
        {
            Raman newRamen = new Raman();

            newRamen.Name = name;
            newRamen.MeatId = meatId;
            newRamen.Broth = broth;
            newRamen.Price = price;

            return newRamen;
        }
    }
}