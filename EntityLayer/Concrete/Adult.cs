using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Adult :Person
    {
        [Key]
        public new int ID { get; set; }
        [Required(ErrorMessage ="Email_Required_Error")]
        [MaxLength(80, ErrorMessage = "Email_Max_Length_Error")]
        [EmailAddress(ErrorMessage = "Email_Error")]
        [Display(Name="Email")]
        public string Email { get; set; }
        [Display(Name="Phone")]
        [Required(ErrorMessage = "Phone_Required_Error")]
        [Phone(ErrorMessage ="Phone_Error")]
        [MaxLength(11,ErrorMessage ="Phone_Max_Length_Error")]
        public string Phone { get; set; }


        
        public AppUser? User { get; set; }
        //public Account Account { get; set; }
        public ICollection<Child>? Childs { get; set; }  // FK çocukları var mı diye
        public ICollection<ShoppingCart>? ShoppingCarts { get; set; } // FK için bir kullanıcının birden fazla heasbı olabilir.

        public Adult()
        {
            Childs= new HashSet<Child>();
            ShoppingCarts=new HashSet<ShoppingCart>();

        }


    }
}
