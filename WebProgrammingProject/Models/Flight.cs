using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models
{
    public class Flight
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime FlightDate { get; set; }





        [Required]
        // FlightLocations arasından seçim yapıyoruz
        public int FromLocation { get; set; } // FK ID  -> flightlocations
        public FlightLocation FromFlightLocation { get; set; }  //FK kolaylik
        [Required]
        public int ToLocation { get; set; } // FK ID -> flightlocations
        public FlightLocation ToFlightLocation { get; set; }  //FK kolaylik
        
        
    }
}
