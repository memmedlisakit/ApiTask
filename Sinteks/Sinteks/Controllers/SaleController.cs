using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sinteks.Models;
using System.Data;
using System.Data.SqlClient;
using Sinteks.Settings;

namespace Sinteks.Controllers
{
    public class SaleController : ApiController
    {
        List<SP_Sale> AllSales = new List<SP_Sale>();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlConnection conn = new SqlConnection(Helper.connectionString);
        int count;

        public SaleController()
        {
            foreach (Seller s in HomeController.getAllSellers())
            {
                foreach (Product p in HomeController.getAllProducts())
                {
                    string query = "EXECUTE sp_Get_Sales_By_ProductId_And_SellerId " + p.Pro_id + ", " + s.Seller_id;
                    using (SqlCommand com = new SqlCommand(query, conn))
                    {
                        da.SelectCommand = com;
                        da.Fill(dt);
                    }     
                }
            }
            foreach (DataRow row in dt.Rows)
            {
                AllSales.Add(new SP_Sale
                {
                    SellerName = row["seller_name"].ToString(),
                    ProductName = row["pro_name"].ToString(),
                    ProductPrice = Convert.ToDouble(row["pro_price"]),
                    ProductAmount = Convert.ToInt32(row["product_amount"]),
                    TotalPrice = Convert.ToDouble(row["total_price"])
                });
            }
        }

        public List<SP_Sale> Get()
        {
            return AllSales;
        }

        public string Get(int id)
        {
            return "value "+count;
        } 
    }
}
