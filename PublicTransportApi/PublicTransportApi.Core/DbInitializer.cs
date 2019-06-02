using PublicTransportApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Core
{
    public static class DbInitializer
    {
        public static void Initialize(DefaultDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                User driver = new User() { FirstName = "Jan", LastName = "Kierowca", Login = "login0", Password = "haslo0", Role = 0 };
                context.Users.Add(driver);
                User setter = new User() { FirstName = "Jan", LastName = "Dystrybutor", Login = "login1", Password = "haslo1", Role = 1 };
                context.Users.Add(setter);
                User manager = new User() { FirstName = "Jan", LastName = "Menadżer", Login = "login2", Password = "haslo2", Role = 2 };
                context.Users.Add(manager);
                User planner = new User() { FirstName = "Jan", LastName = "Planista", Login = "login3", Password = "haslo3", Role = 3 };
                context.Users.Add(planner);
                User admin = new User() { FirstName = "Jan", LastName = "Administrator", Login = "login4", Password = "haslo4", Role = 4 };
                context.Users.Add(admin);

                context.SaveChanges();

            }

            if (!context.Vehicles.Any())
            {
                Vehicle vehicle = new Vehicle { Brand = "Jelcz", Model = "043", Available = true, Mileage = 0.0, Seats = 25, PurchaseDate = DateTime.Now, YearOfProduction = new DateTime(1950, 1, 1) };
                context.Vehicles.Add(vehicle);
                context.SaveChanges();

            }

            if (!context.Failures.Any())
            {
                Failure failure = new Failure { VehicleId = 2, NotifyingUserId = 2, Description = "Nie jeździ", Repaired = true, NotificationDate = new DateTime(2000, 4, 20), AcceptedForRepair = true, PlannedEndOfRepairDate = new DateTime(2001, 05, 1), EndOfRepairDate = new DateTime(2000, 09, 1) };
                context.Failures.Add(failure);
                context.SaveChanges();

            }

            if (!context.TechnicalReviews.Any())
            {
                TechnicalReview technicalReview = new TechnicalReview { VehicleId = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddYears(1), Passed = true };
                context.TechnicalReviews.Add(technicalReview);
                context.SaveChanges();

            }
        }
    }
}
