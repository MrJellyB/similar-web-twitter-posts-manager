using PostManager.DAL.Contexts;
using PostManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostManager.DAL.Services
{

    public interface IPostsRepository
    {
        void CreatePost(Post postToSave);

        Task<bool> SaveChangesAsync();
    }

    public class PostsRepository : BaseFeedRepository, IPostsRepository
    {
        public PostsRepository(FeedContext context) : base(context)
        {
        }

        public void CreatePost(Post postToSave)
        {
            if (postToSave == null)
            {
                throw new ArgumentNullException(nameof(postToSave));
            }

            _context.Add(postToSave);
        }
    }
}
