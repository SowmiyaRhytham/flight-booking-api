using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace FlightBookingAPI.Repository
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly FlightDBContext _context;

        public AirlineRepository (FlightDBContext context)
        {
            _context = context;
        }
        public string CreateAirline(Airline airline)
        {

            try
            {
                _context.Airline.Add(airline);
                var result = _context.SaveChanges();
               // return "Airline Added Successfully!!!";
            }
            catch(Exception ex)
            {
                ex.Source = "AirlineRepository/CreateAirline";
                ExceptionLogging.SendErrorToText(ex);
                ex.ToString();
            }

            return "";
            
        }


    }

}



