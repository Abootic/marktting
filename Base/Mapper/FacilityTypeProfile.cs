using AutoMapper;
using Base.Models.Dto;
using Base.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Mapper
{
    public class FacilityTypeProfile:Profile
    {
        public FacilityTypeProfile()
        {
            CreateMap<FacilityTypeDto, FacilityType>().ReverseMap();
        }
    }
}
