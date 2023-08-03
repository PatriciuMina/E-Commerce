using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_commerce;

namespace E_commerce.Client
{
    public partial class ProductCard : System.Web.UI.UserControl
    {
        public Product Product { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}