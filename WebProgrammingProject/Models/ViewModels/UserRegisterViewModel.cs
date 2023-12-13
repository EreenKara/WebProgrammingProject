using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.ViewModels
{
    public class UserRegisterViewModel
    {
        public Adult Adult{ get; set; }
        public Account Account { get; set; }









        //[Required(ErrorMessage ="Lütfen isminizi giriniz.")]
        //public string FirstName { get; set; }
        //[Required(ErrorMessage = "Lütfen soyisminizi giriniz.")]
        //public string LastName { get; set; }
        //[Required(ErrorMessage = "Lütfen doğum tarihinizi giriniz.")]
        //public DateTime DateofBirth { get; set; }
        //[Required(ErrorMessage = "Lütfen cinsiyetinizi giriniz.")]
        //public bool Gender { get; set; }
        //[Required(ErrorMessage = "Lütfen emailinizi giriniz.")]
        //public string Email { get; set; }
        //[Required(ErrorMessage = "Lütfen telefon numaranızı giriniz.")]
        //public string Phone { get; set; }
        //[Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        //public string Password { get; set; }
        //[Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz.")]
        //[Compare("Password",ErrorMessage ="Şifreler uyuşmuyor.")]
        //public string CheckPassword { get; set; }

    }
}
