using AutoMapper;
using PostManager.Common.Models;
using PostManager.DAL.Entities;

namespace PostManager.BL.Profiles
{
    public class PostsProfile : Profile
    {
        public PostsProfile()
        {
            CreateMap<SendPostRequest, Post>();
            CreateMap<Post, PostResponse>()
                .ForMember(dest => dest.User,
                           opt => opt.MapFrom(post => post.OwnerId))
                .ForMember(dest => dest.Id,
                           opt => opt.MapFrom(post => post.PostId));
        }
    }
}
