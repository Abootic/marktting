using AutoMapper;
using Base.Models.Dto;
using Base.Models.Entity;

namespace Base.Mapper
{
    public class OrderResultProfile:Profile {
        public OrderResultProfile()
        {
            CreateMap<OrderResultDto, OrderResult>().ReverseMap();

        }
    } 
}
