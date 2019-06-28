using AutoMapper;
using PostManager.Common.Models;
using PostManager.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PostManager.BL.Profiles
{
    public class FeedsProfile : Profile
    {
        public FeedsProfile()
        {
            CreateMap<CreateFeedRequest, Feed>()
                .ForMember(dest => dest.RelatedToUser, 
                           opt => opt.MapFrom(src => src.RelatedToUser));

            CreateMap<Feed, FeedResponse>()
                .ForMember(dest => dest.Posts,
                           opt => opt.MapFrom(feed => 
                                    feed.Posts.Select(postsFeed => postsFeed.Post)
                               )) ;
        }
    }
}
