using Ramen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Handler
{
    public class TransactionHeaderHandler
    {
        public static int insertHeader(int customerId, DateTime date)
        {
            return TransactionHeaderRepository.insertHeader(customerId, date);
        }
        public static List<Header> getHeaderByCustomerId(int id)
        {
            return TransactionHeaderRepository.getHeaderByCustomerId(id);
        }

        public static List<Header> getAllHeader()
        {
            return TransactionHeaderRepository.getAllHeader();
        }

        public static List<Header> getAllUnhandledHeader()
        {
            return TransactionHeaderRepository.getAllUnhandledHeader();
        }
        public static void handleHeader(int id, int staffId)
        {
            TransactionHeaderRepository.handleHeader(id, staffId);
        }
    }
}