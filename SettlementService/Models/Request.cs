using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Request
    {
        [Required]
        [RegularExpression(@"(^(?:0?[9]|1[0-5]):[0-5][0-9]$)|(^(?:0?[9]|1[0-6]):[0][0]$)",
            ErrorMessage = "Please enter booking hours between 09:00 AM to 04:00 PM in 24-hour time format")]
        public string BookingTime { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }
    }
}