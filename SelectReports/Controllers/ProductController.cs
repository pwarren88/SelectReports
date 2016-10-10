using SelectReports.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesReportByState.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string[] array)
        {
            PageModel model = new PageModel();
            model.TopProducts = Get().ToArray();
            return View(model);
        }

        public IEnumerable<Product> Get(string state)
        {
            List<Product> model = new List<Product>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "sp_GetTotalQtyByStatePatrickBrian";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@state", state);
                connection.Open();

                using (SqlDataReader r = command.ExecuteReader())
                {

                    while (r.Read())
                    {
                        Product product = new Product();
                        product.id = r.GetInt32(1);
                        product.totalSales = r.GetDecimal(2);
                        product.quantity = r.GetInt32(3);

                        model.Add(product);
                    }
                }
                connection.Close();
                return model;
            }
        }
    }

}