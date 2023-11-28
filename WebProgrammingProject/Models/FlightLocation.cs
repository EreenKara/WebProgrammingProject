using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models
{
    public class FlightLocation
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name="Uculan Yer")]
        public string Name { get; set; }





        public ICollection<Flight> FromLocations { get; set; } //FK için
        public ICollection<Flight> ToLocations { get; set; }// FK için
    }
}
