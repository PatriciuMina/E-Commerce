using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Text;

namespace E_commerce
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ProductsController productsController = new ProductsController();

        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Product> products = productsController.GetAllProducts();
            StringBuilder productsStringBuilder = new StringBuilder("");
            productsStringBuilder.Append("<div class='table-responsive'>");
            productsStringBuilder.Append("<table class='table table-striped table-bordered table-hover'>");
            productsStringBuilder.Append("<thead>");
            productsStringBuilder.Append("<th>Id</th>");
            productsStringBuilder.Append("<th>User_ID</th>");
            productsStringBuilder.Append("<th>Name</th>");
            productsStringBuilder.Append("<th>Price</th>");
            productsStringBuilder.Append("<th>Description</th>");
            productsStringBuilder.Append("<th>Image</th>");
            productsStringBuilder.Append("<th></th>");
            productsStringBuilder.Append("<th></th>");
            productsStringBuilder.Append("</thead>");
            foreach(Product product in products)
            {
                productsStringBuilder.Append("<tr>");
                //Product ID
                productsStringBuilder.Append("<td>");
                productsStringBuilder.Append(product.Id);
                productsStringBuilder.Append("</td>");
                //Product User ID
                productsStringBuilder.Append("<td>");
                productsStringBuilder.Append(product.User_ID);
                productsStringBuilder.Append("</td>");
                //Product Name
                productsStringBuilder.Append("<td>");
                productsStringBuilder.Append(product.Name);
                productsStringBuilder.Append("</td>");
                //Product Price
                productsStringBuilder.Append("<td>");
                productsStringBuilder.Append(product.Price);
                productsStringBuilder.Append("</td>");
                //Product Description
                productsStringBuilder.Append("<td>");
                productsStringBuilder.Append(product.Description);
                productsStringBuilder.Append("</td>");
                //Product Image
                productsStringBuilder.Append("<td>");
                productsStringBuilder.Append(product.Image);
                productsStringBuilder.Append("</td>");
                //Edit Button
                productsStringBuilder.Append("<td>");
                productsStringBuilder.Append("<button type='button' class='edit-button' data-id='" + product.Id + "'> Edit </ button >");
                productsStringBuilder.Append("</td>");
                //Delete Button
                productsStringBuilder.Append("<td>");
                productsStringBuilder.Append("<button type='button' class='delete-button' data-id='" + product.Id + "'> Delete </ button >");
                productsStringBuilder.Append("</td>");

                productsStringBuilder.Append("</tr>");
            }
            productsStringBuilder.Append("</table>");
            productsStringBuilder.Append("</div>");
            ProductTable.Text = productsStringBuilder.ToString();
        }

    }
}