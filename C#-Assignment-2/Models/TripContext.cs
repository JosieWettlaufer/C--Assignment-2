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
                    StartDate = "start",
                    EndDate = "end",
                    Accommodation = "accomodate",
                    ToDo = "activity"
                }
                );
        }
    }
}
