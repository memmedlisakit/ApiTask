using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sinteks.Models
{
    public class Product
    {
        public int Pro_id { get; set; }
        public string Pro_name { get; set; }
        public double Pro_price { get; set; }
        public int Pro_quantity { get; set; }
    }
}