using Base.Models.Dto.BaseDto;
using System.ComponentModel.DataAnnotations;


namespace Base.Models.Dto
{
    public class DepartmentDto: CommonDto
    {
        [Display(Name ="إسم القسم")]
        public string Name { get; set; }
        [Display(Name = "اخرى")]
        public string? other { get; set; }
    }
}
