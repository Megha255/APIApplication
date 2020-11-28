using APIApplication.Dtos;
using APIApplication.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApplication.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            //Source -> Target
            CreateMap<Players, PlayerReadDto>();
            CreateMap<PlayerCreateDto, Players>();
            CreateMap<PlayerUpdateDto, Players>();
            CreateMap<Players, PlayerUpdateDto>();
        }
    }
}
