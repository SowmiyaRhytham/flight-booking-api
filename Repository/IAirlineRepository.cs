using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;

namespace FlightBookingAPI.Repository
{
    public interface IAirlineRepository
    {
        public string CreateAirline(Airline airline);

    }
}
