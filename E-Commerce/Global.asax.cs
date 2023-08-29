﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace E_Commerce
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            var corsAttr = new EnableCorsAttribute("https://localhost:44364", "*", "*");
            GlobalConfiguration.Configuration.EnableCors(corsAttr);

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
                );
        }
    }
}