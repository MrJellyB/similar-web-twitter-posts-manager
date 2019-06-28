using PostManager.DAL.Contexts;
using System.Threading.Tasks;

namespace PostManager.DAL.Services
{
    public abstract class BaseFeedRepository
    {
        protected readonly FeedContext _context;

        public BaseFeedRepository(FeedContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
