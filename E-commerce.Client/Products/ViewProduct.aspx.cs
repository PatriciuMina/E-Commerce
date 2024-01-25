using E_Commerce.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.Client.Products
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string uri = HttpContext.Current.Request.Url.AbsoluteUri;
            Uri myUri = new Uri(uri);
            string id = HttpUtility.ParseQueryString(myUri.Query).Get("parameter");
            ProductsController productsController = new ProductsController();
            try
            {
                Product product = productsController.GetProduct(Int32.Parse(id));
                StringBuilder viewProductString = new StringBuilder("");
                viewProductString.Append("<div class='row'>");
                viewProductString.Append("<div class='col-lg-4'>");
                viewProductString.Append("<div class='card mb-3 border-dark rounded-3'>");

                string imageName = product.Image; 
                string imageDirectory = "~/ProductsImages/"; 
                string imagePath = ResolveUrl(imageDirectory + imageName);
                viewProductString.Append("<img src='" + imagePath + "' alt='" + product.Name + "' class='img-fluid' width='200' height='200'>");
                if (!string.IsNullOrEmpty(product.VideoPath))
                {
                    string videoName = product.VideoPath;
                    string videoDirectory = "~/ProductsVideos/";
                    string videoPath = ResolveUrl(videoDirectory + videoName);
                    viewProductString.Append("<video width='200' height='200' controls>");
                    viewProductString.Append("<source src='" + videoPath + "' type='video/mp4'>");
                    viewProductString.Append("Your browser does not support the video tag.");
                    viewProductString.Append("</video>");
                }

                viewProductString.Append("<h2>" + product.Name + "</h2>");
                viewProductString.Append("<p>Description:</p>");
                viewProductString.Append("<p>" + product.Description + "</p>");
                viewProductString.Append("<p>Price:</p>");
                viewProductString.Append("<p>" + product.Price.ToString() + "$</p>");
                viewProductString.Append("<p>Category:</p>");
                viewProductString.Append("<p>" + product.Category + "</p>");
                viewProductString.Append("</div>");
                viewProductString.Append("</div>");
                viewProductString.Append("</div>");
                viewProductString.Append("</br>");
                JObject json = JObject.Parse(product.Specifications);
                viewProductString.Append("<div class='row'>");
                viewProductString.Append("<div class='col-lg-4'>");
                viewProductString.Append("<ul class='list-group'>");
                foreach (JProperty property in json.Properties())
                {
                    viewProductString.Append("<li class='list-group-item'>");
                    viewProductString.Append(property.Name.ToString() + ": " + property.Value.ToString());
                    viewProductString.Append("</li>");
                }
                viewProductString.Append("</ul>");
                viewProductString.Append("</div>");
                viewProductString.Append("</div>");
                ViewProductLabel.Text = viewProductString.ToString();
            }
            catch (FormatException)
            {
                // The input string is not a valid integer format.
                Console.WriteLine("Invalid input format. Conversion failed.");
            }
            catch (OverflowException)
            {
                // The input string represents a number that is too large or too small to fit into an int.
                Console.WriteLine("Input value is out of range. Conversion failed.");
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that might occur during the conversion.
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}