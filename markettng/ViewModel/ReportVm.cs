using System.ComponentModel.DataAnnotations;

namespace markettng.ViewModel
{
    public class ReportVm
    {
        [Required]
        public DateTime fromDate { get; set; }
     
        public DateTime toDate { get; set; }
        public string? userId { get; set; }
        public int? FacilityTypeId { get; set; }
        public string? TradeName { get; set; }
       

    }
}
