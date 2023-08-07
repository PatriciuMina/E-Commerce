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
            grvProduct.DataSource = products;
            grvProduct.DataBind();
            StringBuilder productsStringBuilder = new StringBuilder("");
            productsStringBuilder.Append("<table border='1'>");
            productsStringBuilder.Append("<tr>");
            productsStringBuilder.Append("<th style='background-color:#00aaaa'>Id</th>");
            productsStringBuilder.Append("<th style='background-color:#00aaaa'>User_ID</th>");
            productsStringBuilder.Append("<th style='background-color:#00aaaa'>Name</th>");
            productsStringBuilder.Append("<th style='background-color:#00aaaa'>Price</th>");
            productsStringBuilder.Append("<th style='background-color:#00aaaa'>Description</th>");
            productsStringBuilder.Append("<th style='background-color:#00aaaa'>Image</th>");
            productsStringBuilder.Append("<th style='background-color:#00aaaa'></th>");
            productsStringBuilder.Append("<th style='background-color:#00aaaa'></th>");
            productsStringBuilder.Append("</tr>");
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
                productsStringBuilder.Append("<button type='button' onclick='EditProduct_Click("+ product.Id +")'> Edit </ button >");
                productsStringBuilder.Append("</td>");
                //Delete Button
                productsStringBuilder.Append("<td>");
                productsStringBuilder.Append("<button type='button' onclick='DeleteProduct_Click(" + product.Id + ")'> Delete </ button >");
                productsStringBuilder.Append("</td>");

                productsStringBuilder.Append("</tr>");
            }
            productsStringBuilder.Append("</table>");
            ProductTable.Text = productsStringBuilder.ToString();
            //ProductTable.AccessKey = productsStringBuilder.ToString();
        }

        protected void grvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void IdSubmitBtn_Click(object sender, EventArgs e)
        {
            int user_Id = Int32.Parse(UserID.Text);
            string name = Name.Text;
            decimal price = decimal.Parse(Price.Text);
            string description = Description.Text;
            string image = Image.Text;
            Product product = new Product(user_Id, name, price, description, image);
            productsController.PostProduct(product);
            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void DeleteProduct_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(((Button)sender).Attributes["data-argument"]);
            productsController.DeleteProduct(id);
            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void EditProduct_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(((Button)sender).Attributes["data-argument"]);
            Response.Redirect("~/EditProduct.aspx?parameter="+id);

        }

    }
}