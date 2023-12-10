using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Flight
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }



        public ICollection<Ticket> Tickets { get; set; }


        [ForeignKey(nameof(Airplane))]
        public int AirplaneID { get; set; }
        public Airplane Airplane { get; set; }


        [ForeignKey(nameof(DepartureAirport))]
        public int DepartureAirportID { get; set; } // FK ID  -> flightlocations
        public Airport DepartureAirport { get; set; }  //FK kolaylik


        [ForeignKey(nameof(ArrivalAirport))]
        public int ArrivalAirportID { get; set; } // FK ID -> flightlocations
        public Airport ArrivalAirport { get; set; }  //FK kolaylik

        public Flight()
        {
            Tickets=new HashSet<Ticket>();
        }

    }
}
