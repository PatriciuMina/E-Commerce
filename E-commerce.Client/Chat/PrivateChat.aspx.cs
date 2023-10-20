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

namespace E_commerce.Client.Chat
{
    public partial class PrivateChat : System.Web.UI.Page
    {
        ConversationController conversationController = new ConversationController();
        MessageController messageController = new MessageController();
        string id1 = null;
        string id2 = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            id1 = HttpContext.Current.User.Identity.GetUserId();
            string uri = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(uri);
            id2 = HttpUtility.ParseQueryString(myUri.Query).Get("parameter");
            if(conversationController.VerifyExistingConversation(id1, id2))
            {
                string username1 = HttpContext.Current.User.Identity.GetUserName();
                UsersController usersController = new UsersController();
                string username2 = usersController.GetUser(id2).UserName;
                Conversation conversation = new Conversation()
                {
                    User_Id1 = id1,
                    UserName1 = username1,
                    User_Id2 = id2,
                    UserName2 = username2,
                };
                conversation = conversationController.StartConversation(conversation);
            }
            IEnumerable<Message> messages = messageController.GetMessagesFromAConversation(id1, id2);
            StringBuilder chatStringBuilder = new StringBuilder("");
            if(messages != null)
            {
                foreach(Message m in messages)
                {
                    if(m.Sender_Id == id1)
                    {
                        chatStringBuilder.Append("<div class='message user1'>");
                        chatStringBuilder.Append(m.Body.ToString());
                        chatStringBuilder.Append("</div>");

                    }
                    if(m.Receiver_Id == id1)
                    {
                        chatStringBuilder.Append("<div class='message user2'>");
                        chatStringBuilder.Append(m.Body.ToString());
                        chatStringBuilder.Append("</div>");

                    }
                }
            }
            Messages.Text = chatStringBuilder.ToString();
        }

        protected void SendMessage(object sender, EventArgs e)
        {
            string message = messageInput.Text;
            Message messageModel = new Message()
            {
                Sender_Id = id1,
                Receiver_Id = id2,
                Body = message
            };
            messageController.SendMessage(messageModel);
            messageInput.Text = string.Empty;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}