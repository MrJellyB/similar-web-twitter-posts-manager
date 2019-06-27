using Microsoft.EntityFrameworkCore;
using PostManager.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostManager.DAL.Factories
{
    public interface IFeedContextFactory
    {
        FeedContext Create();
    }
    public class FeedContextFactory : IFeedContextFactory
    {
        private DbContextOptions<FeedContext> _options;

        public FeedContextFactory(DbContextOptions<FeedContext> options)
        {
            _options = options;
        }

        public FeedContext Create()
        {
            DbContextOptionsBuilder<FeedContext> builder = new DbContextOptionsBuilder<FeedContext>();
            return new FeedContext(builder.Options);
        }
    }
}
