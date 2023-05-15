using AutoMapper;
using Base.Models.Dto;
using Base.Models.Entity;

namespace Base.Mapper
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentDto, Department>().ReverseMap();

        }
    }
}
