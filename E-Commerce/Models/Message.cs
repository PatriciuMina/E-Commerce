using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Sender_Id { get; set; }
        public string Receiver_Id { get; set; }
        public string Body { get; set; }
        public DateTime Created_At { get; set; }
    }
}