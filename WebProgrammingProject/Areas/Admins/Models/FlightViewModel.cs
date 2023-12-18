using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Areas.Admins.Models
{
    public class FlightViewModel
    {
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        [Required]
        public double EconomyPrice { get; set; }
        [Required]
        public double BusinessPrice { get; set; }
        [Required]
        public int DepartureAirportID { get; set; } // FK ID  -> flightlocations
        [Required]
        public int ArrivalAirportID { get; set; } // FK ID -> flightlocations
        [Required]
        public int AirplaneID { get; set; }



    }
}
