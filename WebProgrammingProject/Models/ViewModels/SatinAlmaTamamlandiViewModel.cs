
using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.ViewModels
{
    public class SatinAlmaTamamlandiViewModel
    {
        [Required]
        public int kacKisi { get; set; }
        [Required]
        public HashSet<Person> persons{ get; set; }
        [Required]
        public HashSet<Ticket> tickets{ get; set; }
        [Required]
        public ShoppingCart cart { get; set; }
    }
}
