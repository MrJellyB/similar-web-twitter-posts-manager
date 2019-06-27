using Microsoft.EntityFrameworkCore;
using PostManager.DAL.Enteties;
using PostManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
