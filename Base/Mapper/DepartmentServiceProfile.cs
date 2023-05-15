using AutoMapper;
using Base.Models.Dto;
using Base.Models.Entity;

namespace Base.Mapper
{
    public class DepartmentServiceProfile:Profile {
        public DepartmentServiceProfile()
        {
            CreateMap<DepartmentServiceDto, DepartmentService>().ReverseMap();

        }
    }
}
