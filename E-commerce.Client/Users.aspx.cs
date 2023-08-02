using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Http;
using System.Web.UI.WebControls;
using E_commerce;

namespace E_commerce.Client
{
    public partial class Users : System.Web.UI.Page
    {
        UsersController usersController = new UsersController();
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<User> users = usersController.GetAllUsers();
            grvUser.DataSource = users;
            grvUser.DataBind();
        }

        protected void grvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void IdSubmitBtn_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string email = Email.Text;
            string phonenumber = PhoneNumber.Text;
            string password = Password.Text;
            string role = Role.Text;

            User user = new User(name, email, phonenumber, password, role);
            usersController.PostUser(user);
            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void DeleteUser_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(((Button)sender).Attributes["data-argument"]);
            usersController.DeleteUser(id);
            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void EditUser_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(((Button)sender).Attributes["data-argument"]);
            Response.Redirect("~/EditUser.aspx?parameter=" + id);

        }
    }
}