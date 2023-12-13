using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Account // bu sınıf sadece ve sadece View'lerde kullanılmak için var
    {
        
        [Required(ErrorMessage ="Password_Required_Error")]
        [MinLength(8, ErrorMessage = "Password_Min_Length_Error")]
        [MaxLength(30, ErrorMessage = "Password_Min_Length_Error")]
        [Compare("ConfirmPassword",ErrorMessage = "Password_Compare_Error")]
        [Display(Name ="Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword_Required_Error")]
        [MinLength(8, ErrorMessage = "ConfirmPassword_Min_Length_Error")]
        [MaxLength(30, ErrorMessage = "ConfirmPassword_Max_Length_Error")]
        [Compare("Password",ErrorMessage = "ConfirmPassword_Compare_Error")]
        [Display(Name ="ConfirmPassword")]
        public string ConfirmPassword { get; set; }
        


        //[ForeignKey(nameof(Adult))]
        //public int AdultID { get; set; }// FK için key
        //public Adult Adult { get; set; } // FK için kolaylastirma


    }
}
