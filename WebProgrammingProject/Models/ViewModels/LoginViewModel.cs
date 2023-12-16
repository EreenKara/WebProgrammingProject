using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email_Required_Error")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password_Required_Error")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
