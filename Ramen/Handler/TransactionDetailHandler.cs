using Ramen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Handler
{
    public class TransactionDetailHandler
    {
        public static void insertDetail(int headerId, int ramenId, int quantity)
        {
            TransactionDetailRepository.insertDetail(headerId, ramenId, quantity);
        }
        public static List<Detail> getDetailByHeaderId(int id)
        {
            return TransactionDetailRepository.getDetailByHeaderId(id);
        }
    }
}