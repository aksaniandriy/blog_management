using AutoMapper;
using Blog.Database.Entities;
using Blog.Services.Models;

namespace Blog.Services.Bootstrap
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PostDto, Post>()
                .ReverseMap();

            CreateMap<CommentDto, Comment>()
                .ReverseMap();
        }
    }
}
