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
        public double TotalPrice { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        [ForeignKey(nameof(WhoPaid))]
        public int WhoPaidID { get; set; }
        public Adult WhoPaid { get; set; }
        public ShoppingCart()
        {
            Tickets=new HashSet<Ticket>();
        }
    }
}
