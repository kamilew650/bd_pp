using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PublicTransportApi.Core.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusStop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    YearOfProduction = table.Column<DateTime>(nullable: false),
                    Mileage = table.Column<double>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    Seats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    LineId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Route_Line_LineId",
                        column: x => x.LineId,
                        principalTable: "Line",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Failure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    NotifyingUserId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Repaired = table.Column<bool>(nullable: false),
                    NotificationDate = table.Column<DateTime>(nullable: false),
                    AcceptedForRepair = table.Column<bool>(nullable: false),
                    PlannedEndOfRepairDate = table.Column<DateTime>(nullable: false),
                    EndOfRepairDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Failure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Failure_User_NotifyingUserId",
                        column: x => x.NotifyingUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Failure_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ride",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TicketsCount = table.Column<int>(nullable: false),
                    UsedFuel = table.Column<double>(nullable: false),
                    Delay = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ride", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ride_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ride_User_DriverId",
                        column: x => x.DriverId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ride_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalReview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Passed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalReview_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusStopOnRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RouteId = table.Column<int>(nullable: false),
                    BusStopId = table.Column<int>(nullable: false),
                    PreviousBusStopOnRouteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStopOnRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusStopOnRoute_BusStop_BusStopId",
                        column: x => x.BusStopId,
                        principalTable: "BusStop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusStopOnRoute_BusStopOnRoute_PreviousBusStopOnRouteId",
                        column: x => x.PreviousBusStopOnRouteId,
                        principalTable: "BusStopOnRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusStopOnRoute_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arrival",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    BusStopOnRouteId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrival", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arrival_BusStopOnRoute_BusStopOnRouteId",
                        column: x => x.BusStopOnRouteId,
                        principalTable: "BusStopOnRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arrival_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arrival_BusStopOnRouteId",
                table: "Arrival",
                column: "BusStopOnRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrival_CourseId",
                table: "Arrival",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_BusStopOnRoute_BusStopId",
                table: "BusStopOnRoute",
                column: "BusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_BusStopOnRoute_PreviousBusStopOnRouteId",
                table: "BusStopOnRoute",
                column: "PreviousBusStopOnRouteId",
                unique: true,
                filter: "[PreviousBusStopOnRouteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BusStopOnRoute_RouteId",
                table: "BusStopOnRoute",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Failure_NotifyingUserId",
                table: "Failure",
                column: "NotifyingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Failure_VehicleId",
                table: "Failure",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_CourseId",
                table: "Ride",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_DriverId",
                table: "Ride",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_VehicleId",
                table: "Ride",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_CourseId",
                table: "Route",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_LineId",
                table: "Route",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalReview_VehicleId",
                table: "TechnicalReview",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arrival");

            migrationBuilder.DropTable(
                name: "Failure");

            migrationBuilder.DropTable(
                name: "Ride");

            migrationBuilder.DropTable(
                name: "TechnicalReview");

            migrationBuilder.DropTable(
                name: "BusStopOnRoute");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "BusStop");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Line");
        }
    }
}
