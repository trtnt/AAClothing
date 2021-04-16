using AAClothing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AAClothing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Productmodel> products = new List<Productmodel>();
            DataSet sqlDataSet = new DataSet();

            string connectionString = "Server=DESKTOP-JA9OFG0\\SQLEXPRESS;Database=AAClothing;Trusted_Connection=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Product", connection))
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlDataAdapter.Fill(sqlDataSet);
                }
            }

            foreach (DataRow dr in sqlDataSet.Tables[0].Rows)
            {
                if (products.Where(p => p.Productid == (int)dr["Productid"]).ToList().Count == 0)
                {
                    Productmodel product = new Productmodel()
                    {
                        Productid = (int)dr["Productid"],
                        Productnaam = dr["Productnaam"].ToString(),
                        Productprijs = (double)dr["Productprijs"],
                        Productbeschrijving = dr["Productbeschrijving"].ToString()
                        
                        //ProductImage = (byte[])dr["ProductImage"],

                    };

                    products.Add(product);
                }
                else
                {
                    //products.FirstOrDefault(id => id.ProductId == (long)dr["ProductId"]).ProductCategories.Add(dr["ProductCategoryName"].ToString());
                }

        }
            return View(products);
        }

        public IActionResult productdetails( int id)
        {
            Productmodel product = GetProductbyId(id);
            product.Productid = id;
            return View(product);
        }

        public Productmodel GetProductbyId(int productId)
        {
            string connectionString = "Server=DESKTOP-JA9OFG0\\SQLEXPRESS;Database=AAClothing;Trusted_Connection=True;";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Product WHERE @productId = productId", connection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@Productid", productId);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            Productmodel prod = new Productmodel(productId);
                            while (reader.Read())
                            {
                                prod.Productnaam = reader["ProductNaam"].ToString();
                                prod.Productprijs = (double)reader["Productprijs"];
                                prod.Productbeschrijving = reader["Productbeschrijving"].ToString();

                            }
                            return prod;
                        }
                        else
                        {
                            return new Productmodel(-1);
                        }
                    }
                }
            }
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
