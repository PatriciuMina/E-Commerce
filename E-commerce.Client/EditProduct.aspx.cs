using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class EditProduct : System.Web.UI.Page
    {
        ProductsController productsController = new ProductsController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string parameterValue = Request.QueryString["parameter"];
                Product product = productsController.GetProduct(Int32.Parse(parameterValue));
                UserID.Text = product.User_ID.ToString();
                Name.Text = product.Name;
                Price.Text = ((int)product.Price).ToString();
                Description.Text = product.Description;
                Image.Text = product.Image;
            }

        }

        protected void IdEditBtn_Click(object sender, EventArgs e)
        {
            string parameterValue = Request.QueryString["parameter"];
            int user_Id = Int32.Parse(UserID.Text);
            string name = Name.Text;
            decimal price = decimal.Parse(Price.Text);
            string description = Description.Text;
            string image = Image.Text;
            Product product = new Product(user_Id, name, price, description, image);
            productsController.PutProduct(Int32.Parse(parameterValue), product);
            Response.Redirect("~/Products.aspx?");
        }
    }

}