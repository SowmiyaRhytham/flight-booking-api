using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Repository;
using FlightBookingAPI.Models;
using Microsoft.AspNetCore.Http;

namespace FlightBookingAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class AirlineController : Controller
    {

        private readonly IAirlineRepository _airlineReporitory;

        public AirlineController(IAirlineRepository airlineRepository)
        {
            _airlineReporitory = airlineRepository;
        }

        [HttpPost]
        [Route("GetAirlineDetail")]
        public string CreateAirlineDetail(Airline airline)
        {
            airline.IsBlock = false;
            airline.Createdby = 1;
            return _airlineReporitory.CreateAirline(airline);
        }

    }
}
