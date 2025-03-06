using System.ComponentModel.DataAnnotations;

namespace C__Assignment_2.Models
{
    public class Trip
    {
        //Primary key
        public int TripId { get; set; }

        [Required(ErrorMessage = "Please enter a destination")]
        [StringLength(100, ErrorMessage = "Max 100 characters.")]
        public string? Destination { get; set; }

        [Required(ErrorMessage = "Please enter a start date.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid start date.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter an end date.")]       
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid end date.")]
        public DateTime? EndDate { get; set; }


        //Accommodataions
        [StringLength(100, ErrorMessage = "Max 100 characters.")]
        public string? Accommodation { get; set; }

        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(100, ErrorMessage = "Max 100 characters.")]
        public string? AccomodationPhone { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(100, ErrorMessage = "Max 100 characters.")]
        public string? AccommodationEmail { get; set; }

        //Activities
        [StringLength(200, ErrorMessage = "Max 200 characters.")]
        public string? ThingToDo1 { get; set; }
        [StringLength(200, ErrorMessage = "Max 200 characters.")]
        public string? ThingToDo2 { get; set; }
        [StringLength(200, ErrorMessage = "Max 200 characters.")]
        public string? ThingToDo3 { get; set; }
    }
}
