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
    }
}