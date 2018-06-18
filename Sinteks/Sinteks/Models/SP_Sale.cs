using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sinteks.Models
{
    public class SP_Sale
    {
        public string SellerName { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public double TotalPrice { get; set; }
    }
}