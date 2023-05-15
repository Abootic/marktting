

using Base.Models.Dto.BaseDto;
using System.ComponentModel.DataAnnotations;

namespace Base.Models.Dto
{
    public class DepartmentServiceDto : CommonDto
    {
        public int DepartmentId { get; set; }
        [Display(Name = "إسم الخدمة")]

        public string ServiceName { get; set; }
        [Display(Name = "اخرى")]
        public string? other { get; set; }
    }
}
