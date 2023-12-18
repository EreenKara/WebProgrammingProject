using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.ViewModels
{
    public class FlightBookingViewModel
    {
        public int ID { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        [Required]
        public double EconomyPrice { get; set; }
        [Required]
        public double BusinessPrice { get; set; }
        [Required]
        public Airport DepartureAirport { get; set; } // FK ID  -> flightlocations
        [Required]
        public Airport ArrivalAirport { get; set; } // FK ID -> flightlocations
        [Required]
        public Airplane Airplane { get; set; }

    }
}
