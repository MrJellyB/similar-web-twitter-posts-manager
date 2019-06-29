using AutoMapper;
using PostManager.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersManager.Logic;
using UsersManager.Models;

namespace UsersManager
{
    public class Profiles: Profile
    {
        public Profiles()
        {
            CreateMap<FeedResponse, EnrichedFeed>()
                .ForMember(dest => dest.Posts,
                           opt => opt.MapFrom<UsersRepository>());

            CreateMap<PostResponse, EnrichedPost>();
        }
    }
}
