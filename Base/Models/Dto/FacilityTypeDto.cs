using Base.Models.Dto.BaseDto;

using System.ComponentModel.DataAnnotations;


namespace Base.Models.Dto
{
    public class FacilityTypeDto : CommonDto
    {
        public int? Id { get; set; }
        [Display(Name = "نوع المنشأة")]
        public string Name { get; set; }
        [Display(Name = "اخرى")]
        public string? other { get; set; }
    }
}
