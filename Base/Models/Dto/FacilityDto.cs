
using Base.Models.Dto.BaseDto;
using System.ComponentModel.DataAnnotations;
namespace Base.Models.Dto
{
    public class FacilityDto :CommonDto
    {
       

        [Display(Name ="نوع المنشأة")]
        //public string FacilityType { get; set; }
        public int? FacilityTypeId { get; set; }

        //[Display(Name = "الأهمية ")]
        //public string? Importance { get; set; }
        [Display(Name = "نشاط المنشأة")]
        public string? FacilityActivity { get; set; }
        [Display(Name = "الاسم التجاري  ")]
        public string? TradeName { get; set; }
        [Display(Name = "  اسم المختص")]
        public string? SpecialistName { get; set; }
        [Display(Name = "  صفة المختص")]
        public string? SpecialistAdjective { get; set; }
        [Display(Name = "اسم صاحب القرار")]
        public string? other { get; set; }

        [Display(Name = "  العنوان")]
        public string? Address { get; set; }
        public string? UserId { get; set; }
        public CommunicationChannelDto? communicationChannelDto { get; set; }
        public VisitDto? VisitDto { get; set; }
        public VisitResultDto? visitResultDto { get; set; }
        public FacilityTypeDto? FacilityTypeDto { get; set; }

    }
}
