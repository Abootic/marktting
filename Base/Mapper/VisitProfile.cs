using AutoMapper;
using Base.Models.Dto;
using Base.Models.Entity;

namespace Base.Mapper
{
    public class VisitProfile : Profile {
        public VisitProfile()
        {
            CreateMap<VisitDto, Visit>().ReverseMap();

        }
    }
}
