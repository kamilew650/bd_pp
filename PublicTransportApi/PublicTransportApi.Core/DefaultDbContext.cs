using Microsoft.EntityFrameworkCore;
using PublicTransportApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Core
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {

        }

        public DbSet<Arrival> Arrivals { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<BusStopOnRoute> BusStopsOnRoute { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Failure> Failures { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<TechnicalReview> TechnicalReviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arrival>().ToTable("Arrival");
            modelBuilder.Entity<BusStop>().ToTable("BusStop");
            //modelBuilder.Entity<BusStopOnRoute>().ToTable("BusStopOnRoute").HasOne(x=>x.PreviousBusStopOnRoute).WithOne(y=>y.NextBusStopOnRoute).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey<BusStopOnRoute>(p=>p.PreviousBusStopOnRouteId);
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Failure>().ToTable("Failure");
            modelBuilder.Entity<Line>().ToTable("Line");
            modelBuilder.Entity<Ride>().ToTable("Ride");
            modelBuilder.Entity<Route>().ToTable("Route");
            modelBuilder.Entity<TechnicalReview>().ToTable("TechnicalReview");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
        }
    }
}
