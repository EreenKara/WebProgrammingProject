using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Account // bu sınıf sadece ve sadece
    {
        
        [Required]
        [MinLength(8, ErrorMessage = "8 karakterden daha az sifre olamaz")]
        [MaxLength(30, ErrorMessage = "30 karakterden daha fazla sifre olamaz")]

        public string Password { get; set; }



        //[ForeignKey(nameof(Adult))]
        //public int AdultID { get; set; }// FK için key
        //public Adult Adult { get; set; } // FK için kolaylastirma
        

    }
}
