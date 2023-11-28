using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models
{
    public abstract class Person
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name="Ad")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name="Soyad")]
        public string Surname { get; set; }
        [Required]
        [Display(Name="Dogum Tarihi")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name="Cinsiyet")]
        public bool Gender { get; set; }


        




    }
}
