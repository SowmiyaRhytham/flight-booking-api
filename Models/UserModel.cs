using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Models
{
    public class User
    {
        //public int UserId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Emailid { get; set; }
        public string Phonenumber { get; set; }
        public string Status { get; set; }
    }
}
