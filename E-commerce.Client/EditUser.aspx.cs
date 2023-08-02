using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.Client
{
    public partial class EditUser : System.Web.UI.Page
    {
        UsersController usersController = new UsersController();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string parameterValue = Request.QueryString["parameter"];
                User user = usersController.GetUser(Int32.Parse(parameterValue));
                Name.Text = user.Name;
                Email.Text = user.Email;
                Password.Text = user.Password;
                PhoneNumber.Text = user.PhoneNumber;
                Role.Text = user.Role;
            }

        }

        protected void IdEditBtn_Click(object sender, EventArgs e)
        {
            string parameterValue = Request.QueryString["parameter"];
            string name = Name.Text;
            string email = Email.Text;
            string password = Password.Text;
            string phonenumber = PhoneNumber.Text;
            string role = Role.Text;
            User user = new User(name, email, password, phonenumber, role);
            usersController.PutUser(Int32.Parse(parameterValue), user);
            Response.Redirect("~/Users.aspx?");
        }
    }
}