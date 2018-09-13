using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEST6.MODELS.Model;
using TEST6.API.Models;
using AutoMapper;

namespace TEST6.API.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<customer, CustomerDTO>().ForMember(m => m.FirstName, opt => opt.MapFrom(src => src.first_name)).ForMember(m => m.LastName, opt => opt.MapFrom(src => src.last_name)).ForMember(m => m.Postalcode, opt => opt.MapFrom(src => src.postal_code)).ReverseMap();
        }
    }
}