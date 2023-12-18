using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.ViewModels
{
    public class PassengerInformationViewModel
    {
        [Required]
        public string id { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public int kacKisi { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public List<string> checkedSeats { get; set; }
        //[Required]
        //public List<KisiViewModel> passengerDetails { get; set; }
        [Required(ErrorMessage ="Lutfen bu alani bos gecmeyin")]
        public List<bool> Gender { get; set; }
        [Required(ErrorMessage = "Lutfen bu alani bos gecmeyin")]
        public List<string> FirstName { get; set; }
        [Required(ErrorMessage = "Lutfen bu alani bos gecmeyin")]
        public List<string> LastName { get; set; }
        [Required(ErrorMessage = "Lutfen bu alani bos gecmeyin")]
        public List<DateTime> DateofBirth { get; set; }
        [Required(ErrorMessage = "Lutfen bu alani bos gecmeyin")]
        public List<string> Email { get; set; }
        [Required(ErrorMessage = "Lutfen bu alani bos gecmeyin")]
        public List<string> Tel { get; set; }
        [Required(ErrorMessage = "Lutfen bu alani bos gecmeyin")]
        public List<bool> Accept { get; set; }


    }
}
