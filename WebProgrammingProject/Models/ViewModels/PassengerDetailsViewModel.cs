using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.ViewModels
{
    public class PassengerDetailsViewModel
    {
        [Required]
        public int flightId { get; set; }
        [Required]
        public string flightType { get; set; }
        [Required]
        public int kacKisi { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public List<string> checkedSeats { get; set; }

    }
}
