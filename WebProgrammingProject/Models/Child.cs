using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models
{
    public class Child:Person
    {
        [Key]
        public new int ID { get; set; }






        public int ParentNo { get; set; } // FK ->adult
        public Adult Parent { get; set; } // FK



    }
}
