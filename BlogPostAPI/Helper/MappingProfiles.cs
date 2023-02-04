using AutoMapper;
using BlogPostAPI.Dto;
using BlogPostAPI.Models;

namespace BlogPostAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<Topic, TopicDto>();
            CreateMap<TopicDto, Topic>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            

        }
    }
}
