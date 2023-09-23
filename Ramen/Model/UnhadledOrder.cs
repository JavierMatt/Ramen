using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ramen.Model
{
    public class Order
    {
        public int CustomerId { get; set; }
        public List<ItemDetail> Items { get; set; }
        public DateTime Date { get; set; }
    }
}