using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Areas.Admins.Models
{
    public class AirplaneViewModel
    {
        [Required(ErrorMessage ="Bu alanı doldur")]
        public string AirplaneModel { get; set; }
        [Required(ErrorMessage = "Bu alanı doldur")]
        [RegularExpression(@"((\d+)-){0,2}(\d+)", ErrorMessage ="Lufen sayilari \"-\" ile ayırarak giris yapiniz. 3-3 ve en fazla 3 sayi girebilirsin")]
        public string RowSeatNumberEconomy { get; set; }
        [Required(ErrorMessage = "Bu alanı doldur")]
        [RegularExpression(@"((\d+)-){0,2}(\d+)", ErrorMessage = "Lufen sayilari \"-\" ile ayırarak giris yapiniz. 3-3 ve en fazla 3 sayi girebilirsin")]
        public string ColumnSeatNumberEconomy { get; set; }
        [Required(ErrorMessage = "Bu alanı doldur")]
        [RegularExpression(@"((\d+)-){0,2}(\d+)", ErrorMessage = "Lufen sayilari \"-\" ile ayırarak giris yapiniz. 3-3 ve en fazla 3 sayi girebilirsin")]
        public string RowSeatNumberBusiness { get; set; }
        [Required(ErrorMessage = "Bu alanı doldur")]
        [RegularExpression(@"((\d+)-){0,2}(\d+)", ErrorMessage = "Lufen sayilari \"-\" ile ayırarak giris yapiniz. 3-3 ve en fazla 3 sayi girebilirsin")]
        public string ColumnSeatNumberBusiness { get; set; }


    }
}
