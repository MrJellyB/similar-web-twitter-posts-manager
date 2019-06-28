using AutoMapper;
using PostManager.Common.Models;
using PostManager.DAL.Entities;
using PostManager.DAL.Services;
using PostManager.BL.Extensions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PostManager.BL.Services
{
    public interface IPostsService
    {
        Task Send(SendPostRequest request);
    }

    public class PostsService : IPostsService
    {
        private readonly IMapper _mapper;
        private readonly IPostsRepository _postsRepository;
        private readonly IFeedsRepository _feedsRepository;

        public PostsService(IMapper mapper, IPostsRepository postsRepository, IFeedsRepository feedsRepository)
        {
            _mapper = mapper;
            _postsRepository = postsRepository;
            _feedsRepository = feedsRepository;
        }

        public async Task Send(SendPostRequest request)
        {
            Post postEntity = _mapper.Map<Post>(request);

            var postOwnerFeed = 
                await _feedsRepository.GetOneAsync((feed) => feed.RelatedToUser == request.UserID);
            _feedsRepository.AddToFeed(ref postEntity ,ref postOwnerFeed);

            _postsRepository.CreatePost(postEntity);
            await _postsRepository.SaveChangesAsync();
        }
    }
}
