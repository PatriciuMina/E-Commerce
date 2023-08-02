using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.Client
{
    public partial class EditOrder : System.Web.UI.Page
    {
        OrdersController ordersController = new OrdersController();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string parameterValue = Request.QueryString["parameter"];
                Order order = ordersController.GetOrder(Int32.Parse(parameterValue));
                UserID.Text = order.User_ID.ToString();
                Date.Text = order.Date.ToString("yyyy-MM-dd");
                Total.Text = ((int)order.Total).ToString();
                Address_Id.Text = order.Address_Id.ToString();
            }

        }

        protected void IdEditBtn_Click(object sender, EventArgs e)
        {
            string parameterValue = Request.QueryString["parameter"];
            int user_Id = Int32.Parse(UserID.Text);
            DateTime date = DateTime.ParseExact(Date.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            decimal total = decimal.Parse(Total.Text);
            int address_id = Int32.Parse(Address_Id.Text);
            Order order = new Order(user_Id, date, total, address_id);
            ordersController.PutOrder(Int32.Parse(parameterValue), order);
            Response.Redirect("~/Orders.aspx?");
        }
    }
}