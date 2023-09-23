using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Factory
{
    public class TransactionHeaderFactory
    {
        public static Header createHeader(int CustomerId, DateTime date)
        {
            Header newHeader = new Header();

            newHeader.CustomerId = CustomerId;
            newHeader.Date = date;
            newHeader.StaffId = 0;

            return newHeader;
        }
    }
}