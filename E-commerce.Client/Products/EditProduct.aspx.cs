﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class EditProduct : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Buyer"))
            {
                Response.Redirect("../WarningPages/Warning.aspx");
            }

        }
    }

}