using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Models
{
    public class Flight
    {
      public Int64 Flightid { get;  }
      public Int64 Airlineid { get; set; }
      public string Instrumentused { get; set; }
      public int Totalseats { get; set; }
      public int Totalbusinessseats { get; set; }
      public int Totalnonbusinessseats { get; set; }
      public DateTime Createddate { get; set; }
      public int Createdby { get; set; }
      public DateTime Modifieddate { get; set; }
      public int Modifiedby { get; set; }

    }
}
