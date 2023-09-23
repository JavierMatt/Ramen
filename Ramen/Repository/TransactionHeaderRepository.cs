using Ramen.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Repository
{
    public class TransactionHeaderRepository
    {
        public static LocalDatabaseEntities db = new LocalDatabaseEntities();

        public static int insertHeader(int customerId, DateTime date)
        {
            Header newHeader =  TransactionHeaderFactory.createHeader(customerId, date);
            db.Headers.Add(newHeader);
            db.SaveChanges();
            return newHeader.Id;
        }

        public static List<Header> getAllHeader()
        {
            return (from x in db.Headers select x).ToList();
        }

        public static List<Header> getHeaderByCustomerId(int id)
        {
            return (from x in db.Headers
                    where id == x.CustomerId
                    select x).ToList();
        }

        public static List<Header> getAllUnhandledHeader()
        {
            return (from x in db.Headers
                    where x.StaffId == 0
                    select x).ToList();
        }

        public static void handleHeader(int id, int staffId)
        {
            Header header = (from x in db.Headers
                             where id == x.Id
                             select x).FirstOrDefault();
            header.StaffId = staffId;
            db.SaveChanges();
        }
    }
}