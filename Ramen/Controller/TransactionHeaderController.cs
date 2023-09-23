using Ramen.Handler;
using Ramen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Controller
{
    public class TransactionHeaderController
    {
        public static int insertHeader(int customerId, DateTime date)
        {
            return TransactionHeaderHandler.insertHeader(customerId, date);
        }

        public static List<Header> getHeaderByCustomerId(int id)
        {
            return TransactionHeaderHandler.getHeaderByCustomerId(id);
        }

        public static List<Header> getAllHeader()
        {
            return TransactionHeaderHandler.getAllHeader();
        }

        public static List<Header> getAllUnhandledHeader()
        {
            return TransactionHeaderHandler.getAllUnhandledHeader();
        }

        public static void handleHeader(int id, int staffId)
        {
            TransactionHeaderHandler.handleHeader(id, staffId);
        }
    }
}