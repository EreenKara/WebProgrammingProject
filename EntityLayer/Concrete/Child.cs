using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Child : Person
    {
        [Key]
        public int ID { get; set; }





        [ForeignKey(nameof(Parent))]
        public int ParentID { get; set; } // FK ->adult
        public Adult Parent { get; set; } // FK
    }
}
