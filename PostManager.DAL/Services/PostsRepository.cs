using PostManager.DAL.Contexts;
using PostManager.DAL.Enteties;
using System;
using System.Threading.Tasks;

namespace PostManager.DAL.Services
{

    public interface IPostsRepository
    {
        Task<bool> SavePostAsync(Post postToSave);
    }

    public class PostsRepository : IPostsRepository
    {
        private FeedContext _context;

        public PostsRepository(FeedContext context)
        {
            _context = context;
        }

        public async Task<bool> SavePostAsync(Post postToSave)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return await _context.AddAsync(postToSave) != null;
        }
    }
}
