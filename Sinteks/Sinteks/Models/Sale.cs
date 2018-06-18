using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sinteks.Models
{
    public class Sale
    {
        public int Sal_product_id { get; set; }
        public int Sal_seller_id { get; set; }
        public int Sal_product_amount { get; set; }
        public double Sal_total_price { get; set; } 
    }
}