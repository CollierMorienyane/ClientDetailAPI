using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientInfoAPI.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
    }
}