using PostManager.DAL.Contexts;
using PostManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostManager.DAL.Services
{

    public interface IPostsRepository
    {
        void CreatePost(ref Post postToSave);

        Task<bool> SaveChangesAsync();

        Task IncreaseLikes(string postId);
    }

    public class PostsRepository : BaseFeedRepository, IPostsRepository
    {
        public PostsRepository(FeedContext context) : base(context)
        {
        }

        public async Task IncreaseLikes(string postId)
        {
            var post = await _context.FindAsync<Post>(postId);
            post.LikesCount++;
        }

        public void CreatePost(ref Post postToSave)
        {
            if (postToSave == null)
            {
                throw new ArgumentNullException(nameof(postToSave));
            }

            _context.Add(postToSave);
        }
    }
}
