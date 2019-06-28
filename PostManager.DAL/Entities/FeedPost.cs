using System;
using System.Collections.Generic;
using System.Text;

namespace PostManager.DAL.Entities
{
    public class FeedPost
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int FeedId { get; set; }
        public Feed Feed { get; set; }
    }
}
