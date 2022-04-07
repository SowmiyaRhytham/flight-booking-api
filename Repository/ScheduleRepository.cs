using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;


namespace FlightBookingAPI.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly FlightDBContext _context;

        public ScheduleRepository(FlightDBContext context)
        {
            _context = context;
        }
        public string AddSchedule(Schedule schedule)
        {

            try
            {
                _context.Schedule.Add(schedule);
                var result = _context.SaveChanges();
                // return "Airline Added Successfully!!!";
            }
            catch (Exception ex)
            {
                ex.Source = "ScheduleRepository/AddSchedule";
                ExceptionLogging.SendErrorToText(ex);
                ex.ToString();
            }

            return "";

        }


    }

}
