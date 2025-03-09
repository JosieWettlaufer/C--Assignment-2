using System.ComponentModel.DataAnnotations;

namespace C__Assignment_2.Models
{
    public class Trip
    {
        //Primary key
        public int TripId { get; set; }

        //Not null, 100 char limit
        [Required(ErrorMessage = "Please enter a destination")]
        [StringLength(100, ErrorMessage = "Max 100 characters.")]
        public string? Destination { get; set; }

        //Not null, checks for valid date
        [Required(ErrorMessage = "Please enter a start date.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid start date.")]
        public DateTime? StartDate { get; set; }

        //Not null, checks for valid date
        [Required(ErrorMessage = "Please enter an end date.")]       
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid end date.")]
        public DateTime? EndDate { get; set; }

        //Optional, 100 char limit
        [StringLength(100, ErrorMessage = "Max 100 characters.")]
        public string? Accommodation { get; set; }

        //Optional, valid phone number format, 100 char limit
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(100, ErrorMessage = "Max 100 characters.")]
        public string? AccomodationPhone { get; set; }

        //Optional, valid email address, 100 char limit
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(100, ErrorMessage = "Max 100 characters.")]
        public string? AccommodationEmail { get; set; }

        //Optional, 200 char limit
        [StringLength(200, ErrorMessage = "Max 200 characters.")]
        public string? ThingToDo1 { get; set; }

        //Optional, 200 char limit
        [StringLength(200, ErrorMessage = "Max 200 characters.")]
        public string? ThingToDo2 { get; set; }

        //Optional, 200 char limit
        [StringLength(200, ErrorMessage = "Max 200 characters.")]
        public string? ThingToDo3 { get; set; }
    }
}
