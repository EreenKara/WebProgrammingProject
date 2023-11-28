using System.ComponentModel.DataAnnotations;
namespace WebProgrammingProject.Models
{
    public class AirPlane
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public int NumberofSeats { get; set; }

    }
}
