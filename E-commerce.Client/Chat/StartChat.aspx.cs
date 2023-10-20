using E_Commerce.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.Client
{
    public partial class StartChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            UsersController usersController = new UsersController();
            ConversationController conversationController = new ConversationController();
            IEnumerable<IdentityUser> users = usersController.GetAllUsers();
            StringBuilder usersStringBuilder = new StringBuilder("");
            usersStringBuilder.Append("<div class='row'>");
            usersStringBuilder.Append("<ul class='list-group'>");
            usersStringBuilder.Append("</br>");
            foreach (IdentityUser u in users)
            {
                if(id != u.Id && conversationController.VerifyExistingConversation(id, u.Id))
                {
                    usersStringBuilder.Append("<li class='list-group-item text-center'>");
                    usersStringBuilder.Append("<img src='/Images/profile_picture.jpg' class='img-fluid' width='200' height='200'>");

                    usersStringBuilder.Append("<h2>" + u.UserName + "</h2>");
                    usersStringBuilder.Append("<a class='btn btn-primary rounded-3' id='" + u.Id + "' style='color: white;'  href='../Chat/PrivateChat.aspx?parameter=" + u.Id + "'>Send a message</a>");
                    usersStringBuilder.Append("</li>");
                    usersStringBuilder.Append("</br>");
                }
            }
            usersStringBuilder.Append("</ul>");
            usersStringBuilder.Append("</div>");
            Users.Text = usersStringBuilder.ToString();
        }
    }
}