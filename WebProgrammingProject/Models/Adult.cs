using System.ComponentModel.DataAnnotations;
namespace WebProgrammingProject.Models
{
    public class Adult:Person
    {
        [Key]
        public new int ID { get; set; }
        [Required]
        [MaxLength(80,ErrorMessage ="80 karakterden daha fazla bir email olamaz")]
        [EmailAddress(ErrorMessage = "Email yanlis")]
        public string Email { get; set; }
        [Required]
        public string Phone{ get; set; }





        public ICollection<Child> Childs { get; set; }  // FK çocukları var mı diye
        public ICollection<Account> Accounts { get; set; } // FK için bir kullanıcının birden fazla heasbı olabilir.

    }
}
