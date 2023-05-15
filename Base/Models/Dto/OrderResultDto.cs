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
    public class OrderResultDto : CommonDto
    {
        public int DepartmentServiceId { get; set; }
        public int? FacilityId { get; set; }
        public string? Note { get; set; }
        [Display(Name = "اخرى")]
        public string? other { get; set; }
    }
}
