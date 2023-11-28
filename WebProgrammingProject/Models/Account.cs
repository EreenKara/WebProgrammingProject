using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(80,ErrorMessage ="80 karakterden daha fazla bir email olamaz")]
        [EmailAddress(ErrorMessage ="Email yanlis girildi")]
        public string Email { get; set; }
        [Required]
        [MinLength(8,ErrorMessage ="8 karakterden daha az sifre olamaz")]
        [MaxLength(30,ErrorMessage ="30 karakterden daha fazla sifre olamaz")]
        
        public string Password { get; set; }



        public int PersonID { get; set; }// FK için key
        public Person Person { get; set; } // FK için kolaylastirma


    }
}
