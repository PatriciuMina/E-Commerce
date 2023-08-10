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
                    tableStringBuilder = productsTable();
                    break;
                case "/Orders":
                    tableStringBuilder = ordersTable();
                    break;
                case "/Users":
                    tableStringBuilder = usersTable();
                    break;
                case "/Addresses":
                    tableStringBuilder = addressesTable();
                    break;
            }
            Table.Text = tableStringBuilder.ToString();
        }

        private StringBuilder productsTable()
        {
            ProductsController productsController = new ProductsController();
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
            foreach (Product product in products)
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
            return productsStringBuilder;
        }

        private StringBuilder ordersTable()
        {
            OrdersController ordersController = new OrdersController();
            IEnumerable<Order> orders = ordersController.GetAllOrders();
            StringBuilder ordersStringBuilder = new StringBuilder("");
            ordersStringBuilder.Append("<div class='table-responsive'>");
            ordersStringBuilder.Append("<table class='table table-striped table-bordered table-hover'>");
            ordersStringBuilder.Append("<thead>");
            ordersStringBuilder.Append("<th>Id</th>");
            ordersStringBuilder.Append("<th>User_ID</th>");
            ordersStringBuilder.Append("<th>Date</th>");
            ordersStringBuilder.Append("<th>Total</th>");
            ordersStringBuilder.Append("<th>Address_Id</th>");
            ordersStringBuilder.Append("<th></th>");
            ordersStringBuilder.Append("<th></th>");
            ordersStringBuilder.Append("</thead>");
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
            ordersStringBuilder.Append("</div>");
            return ordersStringBuilder;
        }

        private StringBuilder usersTable()
        {
            UsersController usersController = new UsersController();
            IEnumerable<User> users = usersController.GetAllUsers();
            StringBuilder usersStringBuilder = new StringBuilder("");
            usersStringBuilder.Append("<div class='table-responsive'>");
            usersStringBuilder.Append("<table class='table table-striped table-bordered table-hover'>");
            usersStringBuilder.Append("<thead>");
            usersStringBuilder.Append("<th>Id</th>");
            usersStringBuilder.Append("<th>Name</th>");
            usersStringBuilder.Append("<th>Email</th>");
            usersStringBuilder.Append("<th>Phone Number</th>");
            usersStringBuilder.Append("<th>Passwordr</th>");
            usersStringBuilder.Append("<th>Role</th>");
            usersStringBuilder.Append("<th></th>");
            usersStringBuilder.Append("<th></th>");
            usersStringBuilder.Append("</thead>");

            foreach (User user in users)
            {
                usersStringBuilder.Append("<tr>");
                usersStringBuilder.Append("<td>" + user.Id + "</td>");
                usersStringBuilder.Append("<td>" + user.Name + "</td>");
                usersStringBuilder.Append("<td>" + user.Email + "</td>");
                usersStringBuilder.Append("<td>" + user.PhoneNumber + "</td>");
                usersStringBuilder.Append("<td>" + user.Password + "</td>");
                usersStringBuilder.Append("<td>" + user.Role + "</td>");

                // Edit Button
                usersStringBuilder.Append("<td>");
                usersStringBuilder.Append("<button type='button' class='edit-button' data-id='" + user.Id + "'>Edit</button>");
                usersStringBuilder.Append("</td>");

                // Delete Button
                usersStringBuilder.Append("<td>");
                usersStringBuilder.Append("<button type='button' class='delete-button' data-id='" + user.Id + "'>Delete</button>");
                usersStringBuilder.Append("</td>");

                usersStringBuilder.Append("</tr>");
            }

            usersStringBuilder.Append("</table>");
            usersStringBuilder.Append("</div>");
            return usersStringBuilder;
        }

        private StringBuilder addressesTable()
        {
            AddressController addressController = new AddressController();
            IEnumerable<Address> addresses = addressController.GetAllAddresses();
            StringBuilder addressesStringBuilder = new StringBuilder("");
            addressesStringBuilder.Append("<div class='table-responsive'>");
            addressesStringBuilder.Append("<table class='table table-striped table-bordered table-hover'>");
            addressesStringBuilder.Append("<thead>");
            addressesStringBuilder.Append("<th>Id</th>");
            addressesStringBuilder.Append("<th>User_ID</th>");
            addressesStringBuilder.Append("<th>Address Line 1</th>");
            addressesStringBuilder.Append("<th>Address Line 2</th>");
            addressesStringBuilder.Append("<th>City</th>");
            addressesStringBuilder.Append("<th>Postal Code</th>");
            addressesStringBuilder.Append("<th>Country</th>");
            addressesStringBuilder.Append("<th>Region</th>");
            addressesStringBuilder.Append("<th></th>");
            addressesStringBuilder.Append("<th></th>");
            addressesStringBuilder.Append("</thead>");

            foreach (Address address in addresses)
            {
                addressesStringBuilder.Append("<tr>");
                // Address ID
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.Id);
                addressesStringBuilder.Append("</td>");
                // User ID
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.User_Id);
                addressesStringBuilder.Append("</td>");
                // Address Line 1
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.Address_line1);
                addressesStringBuilder.Append("</td>");
                // Address Line 2
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.Address_line2);
                addressesStringBuilder.Append("</td>");
                // City
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.City);
                addressesStringBuilder.Append("</td>");
                // Postal Code
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.Postal_code);
                addressesStringBuilder.Append("</td>");
                // Country
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.Country);
                addressesStringBuilder.Append("</td>");
                // Region
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append(address.Region);
                addressesStringBuilder.Append("</td>");
                // Edit Button
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append("<button type='button' class='edit-button' data-id='" + address.Id + "'>Edit</button>");
                addressesStringBuilder.Append("</td>");
                // Delete Buttons
                addressesStringBuilder.Append("<td>");
                addressesStringBuilder.Append("<button type='button' class='delete-button' data-id='" + address.Id + "'> Delete </button>");
                addressesStringBuilder.Append("</td>");

                addressesStringBuilder.Append("</tr>");
            }

            addressesStringBuilder.Append("</table>");
            addressesStringBuilder.Append("</div>");
            return addressesStringBuilder;
        }
    }
}