using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Http;
using System.Web.UI.WebControls;

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