using AutoMapper;
using Base.Models.Dto;
using Base.Models.Entity;

namespace Base.Mapper
{
    public class VisitResultProfile : Profile
    {
        public VisitResultProfile()
        {
            CreateMap<VisitResultDto, VisitResult>().ReverseMap();

        }
    }
}
