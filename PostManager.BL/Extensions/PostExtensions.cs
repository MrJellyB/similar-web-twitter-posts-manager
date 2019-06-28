using PostManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostManager.BL.Extensions
{
    public static class PostExtensions
    {
        public static void AddToFeed(this Post post, Feed feed)
        {
            var feedsRelated = post.Feeds ?? new List<FeedPost>();

            feedsRelated.Add(new FeedPost()
            {
                Feed = feed,
                Post = post
            });
        }
    }
}
