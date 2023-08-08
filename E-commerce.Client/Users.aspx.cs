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
            UserTable.Text = usersStringBuilder.ToString();
        }
    }
}