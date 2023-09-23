using Ramen.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Controller
{
    public class TransactionDetailController
    {
        public static void insertDetail(int headerId, int ramenId, int quantity)
        {
            TransactionDetailHandler.insertDetail(headerId, ramenId, quantity);
        }

        public static List<Detail> getDetailByHeaderId(int id)
        {
            return TransactionDetailHandler.getDetailByHeaderId(id);
        }
    }
}