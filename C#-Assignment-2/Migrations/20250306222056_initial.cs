using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C__Assignment_2.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Trips Table
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false), //column constraints
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accommodation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AccomodationPhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AccommodationEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThingToDo1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ThingToDo2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ThingToDo3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId); //Primary key constraint
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Accommodation", "AccommodationEmail", "AccomodationPhone", "Destination", "EndDate", "StartDate", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[] { 1, "Generic Hotel", "generic@gmail.com", "111-111-1111", "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "wake up", "do things", "do more things" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
