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
                    Destination = "New York",
                    StartDate = DateTime.Parse("2004/01/01"),
                    EndDate = DateTime.Parse("2024/01/01"),
                    Accommodation = "Generic Hotel",
                    AccomodationPhone = "111-111-1111",
                    AccommodationEmail = "generic@gmail.com",
                    ThingToDo1 = "wake up",
                    ThingToDo2 = "do things",
                    ThingToDo3 = "do more things"
                }
                );
        }
    }
}
