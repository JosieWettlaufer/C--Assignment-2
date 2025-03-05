using System.ComponentModel.DataAnnotations;

namespace C__Assignment_2.Models
{
    public class Trip
    {
        //Primary key
        public int TripId { get; set; }

        [Required(ErrorMessage = "Please enter a destination")] //ADD CONSTRAINTS
        public string? Destination { get; set; }

        [Required(ErrorMessage = "Please enter a start date.")] //CONVERT TO DATE!
        public string? StartDate { get; set; }
        var parsedStartDate = Date.Parse()

        [Required(ErrorMessage = "Please enter an end date.")]       //CONVERT TO DATE!
        public string? EndDate { get; set; }


        //Accommodataions
        public string? Accommodation { get; set; }    //nullable

        public string? AccomodationPhone { get; set; }

        public string? AccommodationEmail { get; set; }

        //Activities
        public string? ThingToDo1 { get; set; }
        public string? ThingToDo2 { get; set; }
        public string? ThingToDo3 { get; set; }
    }
}
