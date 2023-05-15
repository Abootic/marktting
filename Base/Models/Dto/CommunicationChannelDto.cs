using Base.Models.Dto.BaseDto;
using System.ComponentModel.DataAnnotations;

namespace Base.Models.Dto
{
    public class CommunicationChannelDto: CommonDto
    {
     
        public int? FacilityId { get; set; }
        [Display(Name ="الرابط")]
        public string? Link { get; set; }
        [Display(Name = "نوع قنات الاتصال")]
        public int? ChannelType { get; set; }
        [Display(Name = "رقم الهاتف")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "رقم هاتف المالك")]
        public string? other { get; set; }

    }
}
