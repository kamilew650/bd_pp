﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PublicTransportApi.Core;

namespace PublicTransportApi.Core.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    partial class DefaultDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PublicTransportApi.Core.Entities.Arrival", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusStopOnRouteId");

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("BusStopOnRouteId");

                    b.HasIndex("CourseId");

                    b.ToTable("Arrival");
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.BusStop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BusStop");
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.BusStopOnRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusStopId");

                    b.Property<int?>("PreviousBusStopOnRouteId");

                    b.Property<int>("RouteId");

                    b.HasKey("Id");

                    b.HasIndex("BusStopId");

                    b.HasIndex("PreviousBusStopOnRouteId")
                        .IsUnique()
                        .HasFilter("[PreviousBusStopOnRouteId] IS NOT NULL");

                    b.HasIndex("RouteId");

                    b.ToTable("BusStopOnRoute");
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseType");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.Failure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AcceptedForRepair");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndOfRepairDate");

                    b.Property<DateTime>("NotificationDate");

                    b.Property<int>("NotifyingUserId");

                    b.Property<DateTime>("PlannedEndOfRepairDate");

                    b.Property<bool>("Repaired");

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("NotifyingUserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Failure");
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.Line", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.ToTable("Line");
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.Ride", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("Date");

                    b.Property<TimeSpan>("Delay");

                    b.Property<int>("DriverId");

                    b.Property<int>("TicketsCount");

                    b.Property<double>("UsedFuel");

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("DriverId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Ride");
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<int>("LineId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("LineId");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.TechnicalReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DueDate");

                    b.Property<bool>("Passed");

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("TechnicalReview");
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available");

                    b.Property<string>("Brand");

                    b.Property<double>("Mileage");

                    b.Property<string>("Model");

                    b.Property<DateTime>("PurchaseDate");

                    b.Property<int>("Seats");

                    b.Property<DateTime>("YearOfProduction");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.Arrival", b =>
                {
                    b.HasOne("PublicTransportApi.Core.Entities.BusStopOnRoute", "BusStopOnRoute")
                        .WithMany("Arrivals")
                        .HasForeignKey("BusStopOnRouteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PublicTransportApi.Core.Entities.Course", "Course")
                        .WithMany("Arrivals")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.BusStopOnRoute", b =>
                {
                    b.HasOne("PublicTransportApi.Core.Entities.BusStop", "BusStop")
                        .WithMany("BusStopOnRoutes")
                        .HasForeignKey("BusStopId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PublicTransportApi.Core.Entities.BusStopOnRoute", "PreviousBusStopOnRoute")
                        .WithOne("NextBusStopOnRoute")
                        .HasForeignKey("PublicTransportApi.Core.Entities.BusStopOnRoute", "PreviousBusStopOnRouteId");

                    b.HasOne("PublicTransportApi.Core.Entities.Route", "Route")
                        .WithMany("BusStopsOnRoute")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.Failure", b =>
                {
                    b.HasOne("PublicTransportApi.Core.Entities.User", "NotifyingUser")
                        .WithMany("NotifiedFailures")
                        .HasForeignKey("NotifyingUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PublicTransportApi.Core.Entities.Vehicle", "Vehicle")
                        .WithMany("Failures")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.Ride", b =>
                {
                    b.HasOne("PublicTransportApi.Core.Entities.Course", "Course")
                        .WithMany("Rides")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PublicTransportApi.Core.Entities.User", "Driver")
                        .WithMany("Rides")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PublicTransportApi.Core.Entities.Vehicle", "Vehicle")
                        .WithMany("Rides")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.Route", b =>
                {
                    b.HasOne("PublicTransportApi.Core.Entities.Course", "Course")
                        .WithMany("Routes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PublicTransportApi.Core.Entities.Line", "Line")
                        .WithMany("Routes")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PublicTransportApi.Core.Entities.TechnicalReview", b =>
                {
                    b.HasOne("PublicTransportApi.Core.Entities.Vehicle", "Vehicle")
                        .WithMany("TechnicalReviews")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
