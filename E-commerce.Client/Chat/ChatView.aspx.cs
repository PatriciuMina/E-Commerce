using E_Commerce.Controllers;
using E_Commerce.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.Client
{
    public partial class ChatView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConversationController conversationController = new ConversationController();
            string id1 = System.Web.HttpContext.Current.User.Identity.GetUserId();
            IEnumerable<Conversation> conversations = conversationController.GetMyConversations(id1);
            StringBuilder conversationsStringBuilder = new StringBuilder("");
            conversationsStringBuilder.Append("<div class='row'>");
            conversationsStringBuilder.Append("<ul class='list-group'>");
            conversationsStringBuilder.Append("</br>");
            foreach (Conversation c in conversations)
            {
                conversationsStringBuilder.Append("<li class='list-group-item text-center'>");
                conversationsStringBuilder.Append("<img src='/Images/profile_picture.jpg' class='img-fluid' width='200' height='200'>");
                if(c.User_Id1 == id1)
                {
                    conversationsStringBuilder.Append("<h2>" + c.UserName2 + "</h2>");
                    conversationsStringBuilder.Append("<a class='btn btn-primary rounded-3' id='" + c.User_Id2 + "' style='color: white;'  href='../Chat/PrivateChat.aspx?parameter=" + c.User_Id2 + "'>Send a message</a>");
                }
                else
                {
                    conversationsStringBuilder.Append("<h2>" + c.UserName1 + "</h2>");
                    conversationsStringBuilder.Append("<a class='btn btn-primary rounded-3' id='" + c.User_Id1 + "' style='color: white;'  href='../Chat/PrivateChat.aspx?parameter=" + c.User_Id1 + "'>Send a message</a>");

                }
                conversationsStringBuilder.Append("</li>");
                conversationsStringBuilder.Append("</br>");
            }
            conversationsStringBuilder.Append("</ul>");
            conversationsStringBuilder.Append("</div>");
            Conversations.Text = conversationsStringBuilder.ToString();

        }    
    }
}