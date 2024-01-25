using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;


namespace E_commerce.Client.Products
{
    public partial class Products_Client_Page : System.Web.UI.Page
    {
        ProductsController productsController = new ProductsController();
        StringBuilder productsStringBuilder = new StringBuilder("");

        protected void Page_Load(object sender, EventArgs e)
        {
            list_products.ServerClick += new EventHandler(this.List_Products_Click);
            cards_products.ServerClick += new EventHandler(this.Card_Products_Click);
            Card_Products_Click(sender, e);
        }

        void List_Products_Click(object sender, EventArgs e)
        {
            productsStringBuilder = new StringBuilder("");
            IEnumerable<E_Commerce.Models.Product> products = productsController.GetAllProducts();
            productsStringBuilder.Append("<div class='row'>");
            productsStringBuilder.Append("<ul class='list-group'>");
            productsStringBuilder.Append("</br>");
            foreach (E_Commerce.Models.Product p in products)
            {
                string imageName = p.Image;
                string imageDirectory = "~/ProductsImages/";
                string imagePath = ResolveUrl(imageDirectory + imageName);
                productsStringBuilder.Append("<img src='" + imagePath + "' alt='" + p.Name + "' class='img-fluid' width='200' height='200'>");
                if (!string.IsNullOrEmpty(p.VideoPath))
                {
                    string videoName = p.VideoPath;
                    string videoDirectory = "~/ProductsVideos/";
                    string videoPath = ResolveUrl(videoDirectory + videoName);
                    productsStringBuilder.Append("<video width='200' height='200' controls>");
                    productsStringBuilder.Append("<source src='" + videoPath + "' type='video/mp4'>");
                    productsStringBuilder.Append("Your browser does not support the video tag.");
                    productsStringBuilder.Append("</video>");
                }
                productsStringBuilder.Append("<li class='list-group-item'>");
                productsStringBuilder.Append("<h2>" + p.Name + "</h2>");
                productsStringBuilder.Append("<p>" + p.Description + "</p>");
                productsStringBuilder.Append("<p>" + p.Price.ToString() + "$</p>");
                productsStringBuilder.Append("<p><a class='btn btn-primary rounded-3' href='../Products/ViewProduct.aspx?parameter=" + p.Id + "'>View</a></p>");
                productsStringBuilder.Append("<p><a class='btn btn-default' href='https://go.microsoft.com/fwlink/?LinkId=301948'>BUY</a></p>");
                productsStringBuilder.Append("</li>");
                productsStringBuilder.Append("</br>");
            }
            productsStringBuilder.Append("</ul>");
            productsStringBuilder.Append("</div>");
            Cards.Text = productsStringBuilder.ToString();
        }

        void Card_Products_Click(object sender, EventArgs e)
        {
            productsStringBuilder = new StringBuilder("");
            IEnumerable<E_Commerce.Models.Product> products = productsController.GetAllProducts();
            int groupSize = 3;
            for (int i = 0; i < products.Count<E_Commerce.Models.Product>(); i += groupSize)
            {
                productsStringBuilder.Append("<div class='row'>");
                for (int j = i; j < i + groupSize && j < products.Count<E_Commerce.Models.Product>(); j++)
                {
                    
                    productsStringBuilder.Append("<div class='col-md-4'>");
                    productsStringBuilder.Append("<div class='card'>");
                    string imageName = products.ElementAt(j).Image;
                    string imageDirectory = "~/ProductsImages/";
                    string imagePath = ResolveUrl(imageDirectory + imageName);
                    productsStringBuilder.Append("<img src='" + imagePath + "' alt='" + products.ElementAt(j).Name + "' class='img-fluid' width='200' height='200'>");
                    if (!string.IsNullOrEmpty(products.ElementAt(j).VideoPath))
                    {
                        string videoName = products.ElementAt(j).VideoPath;
                        string videoDirectory = "~/ProductsVideos/";
                        string videoPath = ResolveUrl(videoDirectory + videoName);
                        productsStringBuilder.Append("<video width='200' height='200' controls>");
                        productsStringBuilder.Append("<source src='" + videoPath + "' type='video/mp4'>");
                        productsStringBuilder.Append("Your browser does not support the video tag.");
                        productsStringBuilder.Append("</video>");
                    }
                    productsStringBuilder.Append("<h2>" + products.ElementAt(j).Name + "</h2>");
                    productsStringBuilder.Append("<p>" + products.ElementAt(j).Description + "</p>");
                    productsStringBuilder.Append("<p>" + products.ElementAt(j).Price.ToString() + "$</p>");
                    productsStringBuilder.Append("<p><a class='btn btn-primary rounded-3' href='../Products/ViewProduct.aspx?parameter=" + products.ElementAt(j).Id + "'>View</a></p>");
                    productsStringBuilder.Append("<p><a class='btn btn-default' href='https://go.microsoft.com/fwlink/?LinkId=301948'>BUY</a></p>");
                    productsStringBuilder.Append("</div>");
                    productsStringBuilder.Append("</div>");
                }

                productsStringBuilder.Append("</div>");
                productsStringBuilder.Append("</br>");
            }
            Cards.Text = productsStringBuilder.ToString();
        }
        
    }
}