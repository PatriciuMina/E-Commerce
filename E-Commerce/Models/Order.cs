using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int User_ID { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int Address_Id { get; set; }

        public Order(int User_ID, DateTime Date, decimal Total, int Address_Id)
        {
            this.User_ID = User_ID;
            this.Date = Date;
            this.Total = Total;
            this.Address_Id = Address_Id;
        }

        public Order() { }
    }
}