using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.Client.Products
{
    public partial class Products_Client_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder productsStringBuilder = new StringBuilder("");
            ProductsController productsController = new ProductsController();
            IEnumerable<Product> products = productsController.GetAllProducts();
            int groupSize = 3;
            for (int i = 0; i < products.Count<Product>(); i += groupSize)
            {
                productsStringBuilder.Append("<div class='row'>");
                for (int j = i; j < i + groupSize && j < products.Count<Product>(); j++)
                {
                    productsStringBuilder.Append("<div class='col-md-4'>");
                    productsStringBuilder.Append("<h2>"+ products.ElementAt(j).Name +"</h2>");
                    productsStringBuilder.Append("<p>"+ products.ElementAt(j).Description + "</p>");
                    productsStringBuilder.Append("<p><a class='btn btn-default' href='https://go.microsoft.com/fwlink/?LinkId=301948'>BUY</a></p>");
                    productsStringBuilder.Append("</div>"); 
                }

                productsStringBuilder.Append("</div>");
            }
            Cards.Text = productsStringBuilder.ToString();
        }
    }
}