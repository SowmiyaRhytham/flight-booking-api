using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;


namespace FlightBookingAPI.Repository
{
    public class FlightRepository : IFlightRepository
    {

        private readonly FlightDBContext _context;

        public FlightRepository(FlightDBContext context)
        {
            _context = context;
        }

        public string AddFlight(Flight flight)
        {

            try
            {
                _context.Flight.Add(flight);
                var result = _context.SaveChanges();
                // return "Airline Added Successfully!!!";
            }
            catch (Exception ex)
            {
                ex.Source = "FlightRepository/AddFlight";
                ExceptionLogging.SendErrorToText(ex);
                ex.ToString();
            }

            return "";

        }


    }
}
