using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Adult :Person
    {
        [Key]
        public new int ID { get; set; }
        [Required]
        [MaxLength(80, ErrorMessage = "80 karakterden daha fazla bir email olamaz")]
        [EmailAddress(ErrorMessage = "Email yanlis")]
        public string Email { get; set; }
        [Required]
        [Phone(ErrorMessage ="Lütfen geçerli bir telefon numarası giriniz.")]
        public string Phone { get; set; }




        public Account Account { get; set; }
        public ICollection<Child> Childs { get; set; }  // FK çocukları var mı diye
        public ICollection<ShoppingCart> ShoppingCarts { get; set; } // FK için bir kullanıcının birden fazla heasbı olabilir.

        public Adult()
        {
            Childs= new HashSet<Child>();
            ShoppingCarts=new HashSet<ShoppingCart>();

        }


    }
}
