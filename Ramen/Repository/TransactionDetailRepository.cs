using Ramen.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Repository
{
    public class TransactionDetailRepository
    {
        public static LocalDatabaseEntities db = new LocalDatabaseEntities();

        public static void insertDetail(int headerId, int ramenId, int quantity)
        {
            Detail newDetail = TransactionDetailFactory .createDetail(headerId, ramenId, quantity);
            db.Details.Add(newDetail);
            db.SaveChanges();
        }

        public static List<Detail> getDetailByHeaderId(int id)
        {
            return (from x in db.Details
                    where id == x.Headerid
                    select x).ToList();
        }
    }
}