using PostManager.DAL.Contexts;
using PostManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.DAL.Services
{
    public interface IFeedsRepository
    {
        void CreateFeed(Feed feedToAdd);

        Task<bool> SaveChangesAsync();
    }


    public class FeedsRepository : BaseFeedRepository, IFeedsRepository
    {
        public FeedsRepository(FeedContext context) : base(context)
        {
        }

        public void CreateFeed(Feed feedToAdd)
        {
            if (feedToAdd == null)
            {
                throw new ArgumentNullException(nameof(feedToAdd));
            }

            _context.Add(feedToAdd);
        }
    }
}
