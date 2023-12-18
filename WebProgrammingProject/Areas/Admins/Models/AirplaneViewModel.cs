using System.ComponentModel.DataAnnotations;

namespace WebProgrammingProject.Areas.Admins.Models
{
    public class AirplaneViewModel
    {
        [Required(ErrorMessage ="Bu alanı doldur")]
        public string AirplaneModel { get; set; }
        [Required(ErrorMessage = "Bu alanı doldur")]
        [MaxLength(5, ErrorMessage = "Bu aln 5 i gecmez")]
        [RegularExpression(@"\d-\d-\d",ErrorMessage ="Lufen 0-0-0 formatında bir deger girin")]
        public string RowSeatNumberEconomy { get; set; }
        [Required(ErrorMessage = "Bu alanı doldur")]
        [MaxLength(5, ErrorMessage = "Bu aln 5 i gecmez")]
        [RegularExpression(@"\d-\d-\d",ErrorMessage ="Lufen 0-0-0 formatında bir deger girin")]
        public string ColumnSeatNumberEconomy { get; set; }
        [Required(ErrorMessage = "Bu alanı doldur")]
        [MaxLength(5, ErrorMessage = "Bu aln 5 i gecmez")]
        [RegularExpression(@"\d-\d-\d",ErrorMessage ="Lufen 0-0-0 formatında bir deger girin")]
        public string RowSeatNumberBusiness { get; set; }
        [Required(ErrorMessage = "Bu alanı doldur")]
        [MaxLength(5, ErrorMessage = "Bu aln 5 i gecmez")]
        [RegularExpression(@"\d-\d-\d",ErrorMessage ="Lufen 0-0-0 formatında bir deger girin")]
        public string ColumnSeatNumberBusiness { get; set; }


    }
}
