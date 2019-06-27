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
        }
    }
}
