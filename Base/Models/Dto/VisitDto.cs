using Base.Models.Dto.BaseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Base.Models.Dto
{
    public class VisitDto : CommonDto
    {
        public int? FacilityId { get; set; }
        [Display(Name ="السبب من الزيارة")]
        public string? Reason { get; set; }
        [Display(Name = "  وقت الزيارة")]
        public DateTime VisitTime { get; set; }
        [Display(Name = "اخرى")]
        public string? other { get; set; }
    }
}
