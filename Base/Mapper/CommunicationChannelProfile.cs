using Base.Models.Dto;
using Base.Models.Entity;
using AutoMapper;

namespace Base.Mapper
{
    public class CommunicationChannelProfile:Profile
    {
        public CommunicationChannelProfile()
        {
            CreateMap<CommunicationChannelDto, CommunicationChannel>().ReverseMap();

        }
    }
}
