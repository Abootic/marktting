using Base.Models.Dto.BaseDto;
using System.ComponentModel.DataAnnotations;

namespace Base.Models.Dto
{
    public class VisitResultDto: CommonDto
    {
        public int? FacilityId { get; set; }
        [Display(Name = "درجة الاهمية")]
        public string? ResultType { get; set; }
        [Display(Name = " النتيجة")]
        public string? Message { get; set; }
        public string? Code { get; set; }
        [Display(Name = "اخرى")]
        public string? other { get; set; }
        [Display(Name = "ملاحظة")]
        public string? Note { get; set; }
    }
}
