using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Ticket
    {
        public int ID { get; set; }
        public string SeatNumber { get; set; }
        public double Price { get; set; }
        [ForeignKey(nameof(Flight))]
        public int FlightID { get; set; }
        public Flight Flight { get; set; }
        [ForeignKey(nameof(Person))]
        public int PersonID { get; set; }
        public Person Person { get; set; } // People
    }
}
