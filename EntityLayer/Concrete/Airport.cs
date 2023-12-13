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
        [Required(ErrorMessage ="AirportCode_Required_Error")]
        [MaxLength(200,ErrorMessage ="AirportCode_Max_Length_Error")]
        [Display(Name = "AirportCode")]
        //OnModelCreating tarafında bunu unique yaptım.
        public string AirportCode { get; set; } 
        [Required(ErrorMessage = "Country_Required_Error")]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "City_Required_Error")]
        [Display(Name = "City")]
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
