using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.Client.Controls
{
    public partial class TablesControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pathname = Request.Url.AbsolutePath;
            StringBuilder tableStringBuilder = new StringBuilder();
            switch (pathname)
            {
                case "/Products":
                    ProductsController productsController = new ProductsController();
                    IEnumerable<Product> products = productsController.GetAllProducts();
                    tableStringBuilder = GenerateTable(products);
                    break;
                case "/Orders":
                    OrdersController ordersController = new OrdersController();
                    IEnumerable<Order> orders = ordersController.GetAllOrders();
                    tableStringBuilder = GenerateTable(orders);
                    break;
                case "/Users":
                    UsersController usersController = new UsersController();
                    IEnumerable<User> users = usersController.GetAllUsers();
                    tableStringBuilder = GenerateTable(users);
                    break;
                case "/Addresses":
                    AddressController addressController = new AddressController();
                    IEnumerable<Address> addresses = addressController.GetAllAddresses();
                    tableStringBuilder = GenerateTable(addresses);
                    break;
            }
            Table.Text = tableStringBuilder.ToString();
        }

        private StringBuilder GenerateTable(IEnumerable<object> items)
        {
            if (items == null || !items.Any())
            {
                return new StringBuilder("<p>No items to display.</p>");
            }

            StringBuilder tableBuilder = new StringBuilder();
            tableBuilder.Append("<div class='table-responsive'>");
            tableBuilder.Append("<table class='table table-striped table-bordered table-hover'>");
            tableBuilder.Append("<thead>");

            // Generate table header
            tableBuilder.Append("<tr>");
            foreach (var propertyInfo in items.First().GetType().GetProperties())
            {
                tableBuilder.Append("<th>");
                tableBuilder.Append(propertyInfo.Name);
                tableBuilder.Append("</th>");
            }
            tableBuilder.Append("<th></th>");
            tableBuilder.Append("<th></th>");
            tableBuilder.Append("</tr>");

            tableBuilder.Append("</thead>");
            tableBuilder.Append("<tbody>");

            // Generate table rows
            foreach (var item in items)
            {
                tableBuilder.Append("<tr>");
                foreach (var propertyInfo in item.GetType().GetProperties())
                {
                    tableBuilder.Append("<td>");
                    tableBuilder.Append(propertyInfo.GetValue(item));
                    tableBuilder.Append("</td>");
                }
                tableBuilder.Append("<td>");
                tableBuilder.Append("<button type='button' class='edit-button' data-id='" + item.GetType().GetProperty("Id").GetValue(item) + "'> Edit </ button >");
                tableBuilder.Append("</td>");
                tableBuilder.Append("<td>");
                tableBuilder.Append("<button type='button' class='delete-button' data-id='" + item.GetType().GetProperty("Id").GetValue(item) + "'> Delete </ button >");
                tableBuilder.Append("</td>");
                tableBuilder.Append("</tr>");
            }

            tableBuilder.Append("</tbody>");
            tableBuilder.Append("</table>");
            tableBuilder.Append("</div>");

            return tableBuilder;
        }
    }
}