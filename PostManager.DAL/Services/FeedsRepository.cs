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

        void AddToFeed(ref Post post, ref Feed feed);

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
            var result = _context.Feeds
                .Include(f => f.Posts)
                .ThenInclude(p => p.Post);

            return await result.FirstOrDefaultAsync(condition);
        }

        public void AddToFeed(ref Post post, ref Feed feed)
        {
            if (post == null)
                throw new ArgumentException(nameof(post));

            if (feed.Posts == null)
                feed.Posts = new List<FeedPost>();
            feed.Posts.Add(new FeedPost()
            {
                Post = post,
                Feed = feed
            });
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
