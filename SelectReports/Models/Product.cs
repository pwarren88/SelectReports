using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelectReports.Models
{
    public class Product
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public decimal totalSales { get; set; }
    }

    public class PageModel
    {
        public string[] States { get; set; }
        public string SelectedState { get; set; }
        public Product[] TopProducts { get; set; }
    }
}