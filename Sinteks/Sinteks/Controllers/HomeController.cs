using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Sinteks.Settings;
using Sinteks.Models;

namespace Sinteks.Controllers
{
    public class HomeController : Controller
    {
        public static SqlDataAdapter da = new SqlDataAdapter();
        public static DataTable dt = new DataTable();
        public static SqlConnection conn = new SqlConnection(Helper.connectionString);
        public static string query = "SELECT * FROM ";


        public ActionResult Index()
        { 
            ViewBag.products = getAllProducts();
            
            
            ViewBag.sellers = getAllSellers();
            return View();
        }


        [HttpPost]
        public ActionResult Index(Sale sale)
        {
            string query = "EXECUTE sp_Insert_Sale " +
                sale.Sal_product_id + ", " +
                sale.Sal_seller_id + ", " +
                sale.Sal_product_amount + ", " +
                sale.Sal_total_price;
            using(SqlCommand com =new SqlCommand(query, conn))
            {
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
            } 
            return RedirectToAction("Index");
        }

       public static List<Product> getAllProducts()
        {
            dt.Clear(); 
            using (SqlCommand com = new SqlCommand(query + "Products", conn))
            {
                da.SelectCommand = com;
                da.Fill(dt);
            }

            List<Product> products = new List<Product>();
            foreach (DataRow pro in dt.Rows)
            {
                products.Add(new Product
                {
                    Pro_id = Convert.ToInt32(pro["pro_id"]),
                    Pro_name = pro["pro_name"].ToString(),
                    Pro_price = Convert.ToDouble(pro["pro_price"]),
                    Pro_quantity = Convert.ToInt32(pro["pro_quantity"])
                });
            } 
            return products;
        }
            

        public static List<Seller> getAllSellers()
        {
            dt.Clear();
            using (SqlCommand com = new SqlCommand(query + "Sellers", conn))
            {
                da.SelectCommand = com;
                da.Fill(dt);
            }

            List<Seller> sellers = new List<Seller>();

            foreach (DataRow sel in dt.Rows)
            {
                sellers.Add(new Seller
                {
                    Seller_id = Convert.ToInt32(sel["seller_id"]),
                    Seller_name = sel["seller_name"].ToString()
                });
            }
            return sellers;
        } 
    }
}
