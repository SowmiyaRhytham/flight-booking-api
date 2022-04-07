using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Models
{
    public class Airline
    {
        public string Airlinename { get; set; }
        public string Address { get; set; }
        public string Contactnumbar { get; set; }
        public bool IsBlock { get; set; }
        public int Createdby { get; set; }
    }
}
