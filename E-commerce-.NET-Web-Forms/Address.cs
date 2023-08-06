using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace E_commerce
{
    public class Address
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Address_line1 { get; set; }
        public string Address_line2 { get; set; }
        public string City { get; set; }
        public string Postal_code { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }

        public Address(int Id, int userId, string addressLine1, string addressLine2, string city, string postalCode, string country, string region)
        {
            this.Id = Id;
            this.User_Id = userId;
            this.Address_line1 = addressLine1;
            this.Address_line2 = addressLine2;
            this.City = city;
            this.Postal_code = postalCode;
            this.Country = country;
            this.Region = region;
        }

        public Address(int userId, string addressLine1, string addressLine2, string city, string postalCode, string country, string region)
        {
            this.User_Id = userId;
            this.Address_line1 = addressLine1;
            this.Address_line2 = addressLine2;
            this.City = city;
            this.Postal_code = postalCode;
            this.Country = country;
            this.Region = region;
        }

        // Default constructor
        public Address()
        {
            
        }

    }
}