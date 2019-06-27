using Microsoft.EntityFrameworkCore;
using PostManager.DAL.Entities;

namespace PostManager.DAL.Contexts
{
    public class FeedContext : DbContext
    {
        public FeedContext(DbContextOptions<FeedContext> options) : base(options)
        { }

        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
