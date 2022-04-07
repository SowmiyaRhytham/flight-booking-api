using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingAPI.Models
{
    public class Schedule
    {
        public Int64 Scheduleid { get; }
        public Int64 Airlineid { get; set; }
        public Int64 Flightid { get; set; }
        public string Arrivaltime { get; set; }
        public string Depaturetime { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Scheduledays { get; set; }
        public int Tickecostforbusiness { get; set; }
        public int Tickecostfornonbusiness { get; set; }
        public int Mealpreference { get; set; }
        public DateTime Createddate { get; set; }
        public int Createdby { get; set; }
        public DateTime Modifieddate { get; set; }
        public int Modifiedby { get; set; }
    }
}
