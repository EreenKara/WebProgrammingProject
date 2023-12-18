using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.ViewModels
{
    public class PassengerInformationViewModel
    {
        public string id { get; set; }
        public string type { get; set; }
        public int kacKisi { get; set; }
        public double price { get; set; }
        [Required]
        public List<string> checkedSeats { get; set; }
        //[Required]
        //public List<KisiViewModel> passengerDetails { get; set; }
        [Required]
        public List<bool> Gender { get; set; }
        [Required]
        public List<string> FirstName { get; set; }
        [Required]
        public List<string> LastName { get; set; }
        [Required]
        public List<DateTime> DateofBirth { get; set; }
        [Required]
        public List<string> Email { get; set; }
        [Required]
        public List<string> Tel { get; set; }
        [Required]
        public List<bool> Accept { get; set; }


    }
}
