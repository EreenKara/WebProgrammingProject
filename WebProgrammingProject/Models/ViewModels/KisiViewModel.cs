using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.ViewModels
{
    public class KisiViewModel
    {
        [Required]
        public bool Gender { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Tel { get; set; }
        [Required]
        public bool Accept { get; set; }
    }
}
