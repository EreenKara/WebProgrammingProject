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
        [Required(ErrorMessage ="Model_Required_Error")]
        [MaxLength(200,ErrorMessage ="Model_Max_Length_Error")]
        [Display(Name ="Model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "RowSeatNumberEconomy_Required_Error")]
        [Display(Name ="RowSeatNumberEconomy")]
        public int RowSeatNumberEconomy { get; set; }
        [Required(ErrorMessage = "ColumnSeatNumberEconomy_Required_Error")]
        [Display(Name = "ColumnSeatNumberEconomy")]
        public int ColumnSeatNumberEconomy { get; set; }
        [Required(ErrorMessage = "RowSeatNumberBusiness_Required_Error")]
        [Display(Name = "RowSeatNumberBusiness")]
        public int RowSeatNumberBusiness { get; set; }
        [Required(ErrorMessage = "ColumnSeatNumberBusiness_Required_Error")]
        [Display(Name = "ColumnSeatNumberBusiness")]
        public int ColumnSeatNumberBusiness { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public Airplane()
        {
                Flights=new HashSet<Flight>();
        }

    }
}
