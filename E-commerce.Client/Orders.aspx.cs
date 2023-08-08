using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
            StringBuilder ordersStringBuilder = new StringBuilder("");
            ordersStringBuilder.Append("<table border='1'>");
            ordersStringBuilder.Append("<tr>");
            ordersStringBuilder.Append("<th style='background-color:#00aaaa'>Id</th>");
            ordersStringBuilder.Append("<th style='background-color:#00aaaa'>User_ID</th>");
            ordersStringBuilder.Append("<th style='background-color:#00aaaa'>Date</th>");
            ordersStringBuilder.Append("<th style='background-color:#00aaaa'>Total</th>");
            ordersStringBuilder.Append("<th style='background-color:#00aaaa'>Address_Id</th>");
            ordersStringBuilder.Append("<th style='background-color:#00aaaa'></th>");
            ordersStringBuilder.Append("<th style='background-color:#00aaaa'></th>");
            ordersStringBuilder.Append("</tr>");
            foreach (Order order in orders)
            {
                ordersStringBuilder.Append("<tr>");
                //Order ID
                ordersStringBuilder.Append("<td>");
                ordersStringBuilder.Append(order.Id);
                ordersStringBuilder.Append("</td>");
                //Order User ID
                ordersStringBuilder.Append("<td>");
                ordersStringBuilder.Append(order.User_ID);
                ordersStringBuilder.Append("</td>");
                //Order Date
                ordersStringBuilder.Append("<td>");
                ordersStringBuilder.Append(order.Date);
                ordersStringBuilder.Append("</td>");
                //Order Total
                ordersStringBuilder.Append("<td>");
                ordersStringBuilder.Append(order.Total);
                ordersStringBuilder.Append("</td>");
                //Order Address ID
                ordersStringBuilder.Append("<td>");
                ordersStringBuilder.Append(order.Address_Id);
                ordersStringBuilder.Append("</td>");
                //Edit Button
                ordersStringBuilder.Append("<td>");
                ordersStringBuilder.Append("<button type='button' class='edit-button' data-id='" + order.Id + "'> Edit </ button >");
                ordersStringBuilder.Append("</td>");
                //Delete Button
                ordersStringBuilder.Append("<td>");
                ordersStringBuilder.Append("<button type='button' class='delete-button' data-id='" + order.Id + "'> Delete </ button >");
                ordersStringBuilder.Append("</td>");

                ordersStringBuilder.Append("</tr>");
            }
            ordersStringBuilder.Append("</table>");
            OrderTable.Text = ordersStringBuilder.ToString();
        }

    }
}