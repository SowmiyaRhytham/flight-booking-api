using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace FlightBookingAPI.Models
{
    public class FlightDBContext:DbContext
    { 

        public FlightDBContext(DbContextOptions<FlightDBContext> options)
            :base(options)
        {
            Database.EnsureCreated();

        }
      
        public DbSet<User> User { get; set; }
        public DbSet<Airline> Airline { get; set; }
        public DbSet<Flight> Flight { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.Entity<User>().ToTable("Admin").HasKey(t => t.Emailid);
            modelBuilder.Entity<User>().ToTable("mst_user").HasKey(t => t.Emailid);
            modelBuilder.Entity<Airline>().ToTable("mst_Airline").HasKey(t => t.Airlinename);
            modelBuilder.Entity<Flight>().ToTable("mst_Flight").HasKey(t => t.Flightid);
        }

    }
}
