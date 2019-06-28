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
        private readonly IUsersRepository _usersRepository;

        public Profiles(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Profiles()
        {
            CreateMap<FeedResponse, EnrichedFeed>()
                .ForMember(dest => dest.Posts,
                           opt => opt.MapFrom(feed =>
                              feed.Posts.Select(post => _usersRepository.Fetch(post.User))
                           ));
        }
    }
}
