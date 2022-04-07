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

    public class ScheduleController : Controller
    {

        private readonly IScheduleRepository _scheduleReporitory;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleReporitory = scheduleRepository;
        }

        [HttpPost]
        [Route("GetAirlineDetail")]
        public string GetFlightDetail(Schedule schedule)
        {
            return _scheduleReporitory.AddSchedule(schedule);
        }



    }
}
