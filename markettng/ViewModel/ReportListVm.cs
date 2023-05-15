using System.ComponentModel.DataAnnotations;
namespace markettng.ViewModel
{
    public class ReportListVm
    {
        [Display(Name = "التاريخ")]
        public DateTime Date { get; set; }
        [Display(Name = "المنشأة")]
        public string facilityName { get; set; }
            [Display(Name = "  نشاط المنشأة")]
        public string facilityActivity { get; set; }
        [Display(Name = "نوعها")]
        public string facilityType { get; set;}
        [Display(Name = "رقم الهاتف")]
        public string phoneNubmer { get; set;}
        public string? username { get; set;}
        [Display(Name = "نتيجة الزيارة")]
        public string vistType { get;set;}
        [Display(Name = " ملاحظة")]
        public string Note { get;set;}
        [Display(Name = "رقم الزيارة")]
        public int vistId { get; set; }
        [Display(Name = " العنوان")]
        public string address { get; set;}

    }
}
