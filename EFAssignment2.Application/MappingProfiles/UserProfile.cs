using EFAssignment2.Application.Dtos;
using AutoMapper;
using EFAssignment2.Core.Entities;
using System;

namespace EFAssignment2.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}

