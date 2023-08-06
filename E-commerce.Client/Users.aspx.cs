using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Http;
using System.Web.UI.WebControls;
using E_commerce;
using System.Text;

namespace E_commerce.Client
{
    public partial class Users : System.Web.UI.Page
    {
        UsersController userController = new UsersController();

        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateUserTable();
        }

        protected void GenerateUserTable()
        {
            IEnumerable<User> users = userController.GetAllUsers();
            StringBuilder usersStringBuilder = new StringBuilder("");

            usersStringBuilder.Append("<table border='1'>");
            usersStringBuilder.Append("<tr>");
            usersStringBuilder.Append("<th style='background-color:#00aaaa'>Id</th>");
            usersStringBuilder.Append("<th style='background-color:#00aaaa'>Name</th>");
            usersStringBuilder.Append("<th style='background-color:#00aaaa'>Email</th>");
            usersStringBuilder.Append("<th style='background-color:#00aaaa'>Phone Number</th>");
            usersStringBuilder.Append("<th style='background-color:#00aaaa'>Passwordr</th>");
            usersStringBuilder.Append("<th style='background-color:#00aaaa'>Role</th>");
            usersStringBuilder.Append("<th style='background-color:#00aaaa'></th>");
            usersStringBuilder.Append("<th style='background-color:#00aaaa'></th>");
            usersStringBuilder.Append("</tr>");

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
            UserTable.Text = usersStringBuilder.ToString();
        }
    }
}