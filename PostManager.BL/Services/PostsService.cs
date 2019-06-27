using AutoMapper;
using PostManager.Common.Models;
using PostManager.DAL.Entities;
using PostManager.DAL.Factories;
using PostManager.DAL.Services;
using System.Threading.Tasks;

namespace PostManager.BL.Services
{
    public interface IPostsService
    {
        Task Send(SendPostRequest request);
    }

    public class PostsService : IPostsService
    {
        private IMapper _mapper;
        private IPostsRepository _postsRepository;

        public PostsService(IMapper mapper, IPostsRepository postsRepository)
        {
            _mapper = mapper;
            _postsRepository = postsRepository;
        }

        public async Task Send(SendPostRequest request)
        {
            var postEntity = _mapper.Map<Post>(request);

            _postsRepository.CreatePost(postEntity);
            await _postsRepository.SaveChangesAsync();
        }
    }
}
