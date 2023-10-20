using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace E_commerce.Client
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder navBarString = new StringBuilder("");
            if (HttpContext.Current.User.IsInRole("Admin")){
                navBarString.Append("<li><a runat='server' href='../Chat/ChatView'>Chat</a></li>");
                navBarString.Append("<li><a href='../Addresses/Addresses.aspx'>Addresses</a></li>");
                navBarString.Append("<li><a href='../Orders/Orders.aspx'>Orders</a></li>");
                navBarString.Append("<li><a href='../Products/Products.aspx'>Products</a></li>");
                navBarString.Append("<li><a href='../Users/Users.aspx'>Users</a></li>");
            }
            else if (HttpContext.Current.User.IsInRole("Seller")) {
                navBarString.Append("<li><a runat='server' href='../Chat/ChatView'>Chat</a></li>");
                navBarString.Append("<li><a href='../Addresses/Addresses.aspx'>Addresses</a></li>");
                navBarString.Append("<li><a href='../Orders/Orders.aspx'>Orders</a></li>");
                navBarString.Append("<li><a href='../Products/Products.aspx'>Products</a></li>");
                navBarString.Append("<li><a href='../Products/Products_Client_Page.aspx'>All Products</a></li>");
            }
            else if (HttpContext.Current.User.IsInRole("Buyer")){
                navBarString.Append("<li><a runat='server' href='../Chat/ChatView'>Chat</a></li>");
                navBarString.Append("<li><a href='../Products/Products_Client_Page.aspx'>All Products</a></li>");
            }
            NavBarItems.Text = navBarString.ToString();

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

}