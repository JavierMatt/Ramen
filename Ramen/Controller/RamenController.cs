using Ramen.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Controller
{
    public class RamenController
    {
        public static List<Raman> getAllRamen()
        {
            return RamenHandler.getAllRamen();
        }

        public static void deleteRamen(int id)
        {
            RamenHandler.deleteRamen(id);
        }

        public static Raman getRamenById(int id)
        {
            return RamenHandler.getRamenById(id);
        }

        public static List<string> insertRamen(string name, int meadId, string broth, string price)
        {
            string errMessageName = "";
            string errMessageBroth = "";
            string errMessagePrice = "";
            bool isRamenValid = true;
            int validPrice;
            if (name == "")
            {
                errMessageName = "Field must be filled";
                isRamenValid = false;
            }
            else if(!name.Contains("Ramen"))
            {
                errMessageName = "Must contains 'Ramen'";
                isRamenValid = false;
            }

            if(broth == "")
            {
                errMessageBroth = "Field must be filled";
                isRamenValid = false;
            }

            bool isPriceValid = int.TryParse(price, out validPrice);


            if (isPriceValid)
            {
                if(validPrice < 3000)
                {
                    errMessagePrice = "Price must be atleast 3000";
                    isRamenValid = false;
                }
            }
            else
            {
                errMessagePrice = "Must be filled with number";
                isRamenValid = false;
            }

            List<string> output = new List<string> { errMessageName, errMessageBroth, errMessagePrice };

            if (isRamenValid == true)
            {
                RamenHandler.addRamen(name, meadId, broth, price);
            }
            return output;
        }

        public static List<string> updateRamen(int id, string name, int meadId, string broth, string price)
        {
            string errMessageName = "";
            string errMessageBroth = "";
            string errMessagePrice = "";
            bool isRamenValid = true;
            int validPrice;
            if (name == "")
            {
                errMessageName = "Field must be filled";
                isRamenValid = false;
            }
            else if (!name.Contains("Ramen"))
            {
                errMessageName = "Must contains 'Ramen'";
                isRamenValid = false;
            }

            if (broth == "")
            {
                errMessageBroth = "Field must be filled";
                isRamenValid = false;
            }

            bool isPriceValid = int.TryParse(price, out validPrice);


            if (isPriceValid)
            {
                if (validPrice < 3000)
                {
                    errMessagePrice = "Price must be atleast 3000";
                    isRamenValid = false;
                }
            }
            else
            {
                errMessagePrice = "Must be filled with number";
                isRamenValid = false;
            }

            List<string> output = new List<string> { errMessageName, errMessageBroth, errMessagePrice };

            if (isRamenValid == true)
            {
                RamenHandler.updateRamen(id, name, meadId, broth, price);
            }
            return output;
        }
    }
}