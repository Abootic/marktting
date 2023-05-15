using AutoMapper;
using Base.Models.Dto;
using Base.Models.Entity;

namespace Base.Mapper
{
    public class FacilityProfile:Profile
    {
        public FacilityProfile() {
            CreateMap<FacilityDto, Facility>().ReverseMap();
        }
    }
}
