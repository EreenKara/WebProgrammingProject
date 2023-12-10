using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Airport
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Airport Code")]
        //OnModelCreating tarafında bunu unique yaptım.
        public string AirportCode { get; set; } 
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }


        [InverseProperty(nameof(Flight.DepartureAirport))]
        public ICollection<Flight> DepartingFlights { get; set; } //FK için

        [InverseProperty(nameof(Flight.ArrivalAirport))]
        public ICollection<Flight> ArrivingFlights { get; set; }// FK için

        public Airport()
        {
            DepartingFlights = new HashSet<Flight>();
            ArrivingFlights = new HashSet<Flight>();
        }


    }
}
