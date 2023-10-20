using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public string User_Id1 { get; set; }
        public string UserName1 { get; set; }
        public string User_Id2 { get; set; }
        public string UserName2 { get; set; }
        public DateTime Created_At { get; set; }
    }
}