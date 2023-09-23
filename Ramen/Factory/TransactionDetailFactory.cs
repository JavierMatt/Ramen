using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Factory
{
    public class TransactionDetailFactory
    {
        public static Detail createDetail(int headerId, int ramenId, int quantity)
        {
            Detail newDetail = new Detail();

            newDetail.Headerid = headerId;
            newDetail.Ramenid = ramenId;
            newDetail.Quantity = quantity;

            return newDetail;
        }
    }
}