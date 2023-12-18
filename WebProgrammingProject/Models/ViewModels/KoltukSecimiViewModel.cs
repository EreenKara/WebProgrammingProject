using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Models.ViewModels
{
    public class KoltukSecimiViewModel
    {
        [Required]
        public string idAndType { get; set; }
        [Required]
        public int kacKisi { get; set; }
    }
}
