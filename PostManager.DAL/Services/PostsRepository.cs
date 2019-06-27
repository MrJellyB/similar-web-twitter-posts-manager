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

    public class PostsRepository : IPostsRepository
    {
        private FeedContext _context;

        public PostsRepository(FeedContext context)
        {
            _context = context;
        }

        public void CreatePost(Post postToSave)
        {
            if (postToSave == null)
            {
                throw new ArgumentNullException(nameof(postToSave));
            }

            try
            {
                _context.Add(new Feed() { FeedId = 1, Posts = new List<Post>() });
                _context.SaveChanges();
                //postToSave.FeedId = 1;
                //postToSave.Feed = new Feed();
                _context.Add(postToSave);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
