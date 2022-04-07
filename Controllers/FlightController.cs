using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;
using FlightBookingAPI.Repository;

namespace FlightBookingAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class FlightController : Controller
    {

        private readonly IFlightRepository _flightReporitory;

        public FlightController(IFlightRepository flightRepository)
        {
            _flightReporitory = flightRepository;
        }

        [HttpPost]
        [Route("GetAirlineDetail")]
        public string GetFlightDetail(Flight flight)
        {
            return _flightReporitory.AddFlight(flight);
        }


    }
}
