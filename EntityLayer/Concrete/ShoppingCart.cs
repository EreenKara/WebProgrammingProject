using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public double Total { get; set; }
        [ForeignKey(nameof(Ticket))]
        public int TicketID { get; set; }
        public Ticket Ticket { get; set; }
        [ForeignKey(nameof(WhoPaid))]
        public int WhoPaidID { get; set; }
        public Adult WhoPaid { get; set; }

    }
}
