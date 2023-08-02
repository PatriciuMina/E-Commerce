using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace E_commerce
{
    public class Product
    {
        public int Id { get; set; }
        public int User_ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Product(int User_ID, string Name, decimal Price, string Description, string Image)
        {
            this.User_ID = User_ID;
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.Image = Image;

        }

        public Product() { }

    }
}