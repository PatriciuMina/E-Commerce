using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int User_ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Specifications { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public string VideoPath { get; set; }

        public Product(int User_ID, string Name, decimal Price, string Description, string Image, string VideoPath, string Category, string Specifications, DateTime Created_At, DateTime Updated_At)
        {
            this.User_ID = User_ID;
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.Image = Image;
            this.VideoPath = VideoPath;
            this.Category = Category;
            this.Specifications = Specifications;
            this.Created_At = Created_At;
            this.Updated_At = Updated_At;
        }

        public Product() { }
    }
}