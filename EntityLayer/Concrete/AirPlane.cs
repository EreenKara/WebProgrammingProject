using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    // Her bir Entity'nin acces modifier'ı public olmak zorunda.
    public class Airplane
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Model { get; set; }
        [Required]
        public int SeatNumberEconomy { get; set; }
        [Required]
        public int SeatNumberBusiness { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public Airplane()
        {
                Flights=new HashSet<Flight>();
        }

    }
}
