using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApplication.Dto;
using UserApplication.Repository;

namespace UserApplication.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest=>dest.City,
                           opt=>opt.MapFrom(src=>src.Address.City))
                .ForMember(dest => dest.Street,
                           opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.Suite,
                           opt => opt.MapFrom(src => src.Address.Suite))
                .ForMember(dest => dest.Zipcode,
                           opt => opt.MapFrom(src => src.Address.Zipcode))
                .ForMember(dest => dest.Lat,
                           opt => opt.MapFrom(src => src.Address.Geo.Lat))
                .ForMember(dest => dest.Lng,
                           opt => opt.MapFrom(src => src.Address.Geo.Lng))

                           ;
        }
    }
}
