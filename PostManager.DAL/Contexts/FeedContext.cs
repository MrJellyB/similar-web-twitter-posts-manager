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

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Many to many key bindings
            builder.Entity<Post>()
                .HasKey(x => x.PostId);

            builder.Entity<Feed>()
                .HasKey(x => x.FeedId);

            builder.Entity<FeedPost>()
                .HasKey(x => new { x.FeedId, x.PostId});
            builder.Entity<FeedPost>()
                .HasOne(x => x.Post)
                .WithMany(m => m.Feeds)
                .HasForeignKey(x => x.PostId);
            builder.Entity<FeedPost>()
                .HasOne(x => x.Feed)
                .WithMany(m => m.Posts)
                .HasForeignKey(x => x.FeedId);

            builder.Entity<Feed>()
                .HasIndex(f => f.RelatedToUser)
                .IsUnique();

            // Default values
            builder.Entity<Post>().Property(p => p.LikesCount).HasDefaultValue(0);
        }
    }
}
