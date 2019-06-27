using PostManager.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostManager.DAL.Entities
{
    public class Feed
    {
        public int FeedId { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
