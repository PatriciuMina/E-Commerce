using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.Client
{
    public partial class Orders : System.Web.UI.Page
    {
        OrdersController ordersController = new OrdersController();
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Order> orders = ordersController.GetAllOrders();
            grvOrder.DataSource = orders;
            grvOrder.DataBind();
        }

        protected void grvOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void IdSubmitBtn_Click(object sender, EventArgs e)
        {
            int user_Id = Int32.Parse(UserID.Text);
            DateTime date = DateTime.ParseExact(Date.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            decimal total = decimal.Parse(Total.Text);
            int address_id = Int32.Parse(Address_Id.Text);
            Order order = new Order(user_Id, date, total, address_id);
            ordersController.PostOrder(order);
            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void DeleteOrder_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(((Button)sender).Attributes["data-argument"]);
            ordersController.DeleteOrder(id);
            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void EditOrder_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(((Button)sender).Attributes["data-argument"]);
            Response.Redirect("~/EditOrder.aspx?parameter=" + id);

        }
    }
}