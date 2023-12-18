using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.ViewModels
{
    public class FlightSearchViewModel
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public DateTime neZaman { get; set; }
        [Required]
        public int kacKisi { get; set; }
    }
}
