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
        Task<int> Send(SendPostRequest request);
        Task Like(string id);
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

        public async Task<int> Send(SendPostRequest request)
        {
            Post postEntity = _mapper.Map<Post>(request);

            var postOwnerFeed = 
                await _feedsRepository.GetOneAsync((feed) => feed.RelatedToUser == request.OwnerId);
            _feedsRepository.AddToFeed(ref postEntity ,ref postOwnerFeed);

            _postsRepository.CreatePost(ref postEntity);
            await _postsRepository.SaveChangesAsync();

            return postEntity.PostId;
        }

        public async Task Like(string id)
        {
            await _postsRepository.IncreaseLikes(id);
        }
    }
}
