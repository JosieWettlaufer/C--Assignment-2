using Microsoft.EntityFrameworkCore;

namespace C__Assignment_2.Models
{
    //Communicates with database
    public class TripContext : DbContext
    {
        //Stores configuration options for DbContext Object
        public TripContext (DbContextOptions<TripContext> options)
            : base(options)
            { }

        //Collection of trip entities
        public DbSet<Trip> Trips { get; set; }

        //Seed inital data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    TripId = 1,
                    Destination = "test dest",
                    StartDate = DateTime.Parse("2004/01/01"),
                    EndDate = DateTime.Parse("2024/01/01"),
                    Accommodation = "accomodate",
                    AccomodationPhone = "testphone",
                    AccommodationEmail = "testemail",
                    ThingToDo1 = "activity1",
                    ThingToDo2 = "activity2",
                    ThingToDo3 = "activity3"
                }
                );
        }
    }
}
