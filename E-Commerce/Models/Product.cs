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

        public Product(int User_ID, string Name, decimal Price, string Description, string Image, string Category, string Specifications)
        {
            this.User_ID = User_ID;
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.Image = Image;
            this.Category = Category;
            this.Specifications = Specifications;
        }

        public Product() { }
    }
}