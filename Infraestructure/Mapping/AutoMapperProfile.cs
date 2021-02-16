using AutoMapper;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Mapping
{
    class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<PostDto, Post>();
            CreateMap<Post, PostDto>();


        }
    }
}
