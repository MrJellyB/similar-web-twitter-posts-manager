using Microsoft.EntityFrameworkCore;
using PostManager.DAL.Contexts;
using PostManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostManager.DAL.Services
{
    public interface IFeedsRepository
    {
        void Create(Feed feedToAdd);

        Task<List<Feed>> GetAllAsync();

        Task<Feed> GetOneAsync(Expression<Func<Feed, bool>> condition);

        Task<bool> SaveChangesAsync();
    }


    public class FeedsRepository : BaseFeedRepository, IFeedsRepository
    {
        public FeedsRepository(FeedContext context) : base(context)
        {
        }

        public async Task<List<Feed>> GetAllAsync()
        {
            return await _context.Feeds.ToListAsync();
        }

        public async Task<Feed> GetOneAsync(Expression<Func<Feed, bool>> condition)
        {
            return await _context.Feeds.FirstOrDefaultAsync(predicate: condition);
        }

        public void Create(Feed feedToAdd)
        {
            if (feedToAdd == null)
            {
                throw new ArgumentNullException(nameof(feedToAdd));
            }

            _context.Add(feedToAdd);
        }
    }
}
