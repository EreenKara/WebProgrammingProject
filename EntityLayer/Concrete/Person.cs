using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public abstract class Person
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="FirstName_Required_Error")]
        [Display(Name ="FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName_Required_Error")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "DateofBirth_Required_Error")]
        [Display(Name = "DateofBirth")]
        public DateTime DateofBirth { get; set; }
        [Required(ErrorMessage = "Gender_Required_Error")]
        [Display(Name ="Gender")]
        public bool Gender { get; set; }

        public ICollection<Ticket> Tickets { get; set; }


        public Person()
        {
            Tickets = new HashSet<Ticket>();
        }
    }
}
