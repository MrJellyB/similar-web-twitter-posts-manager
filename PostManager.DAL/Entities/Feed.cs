using PostManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PostManager.DAL.Entities
{
    public class Feed
    {
        public int FeedId { get; set; }

        [Required]
        public string RelatedToUser { get; set; }

        public ICollection<FeedPost> Posts { get; set; }
    }
}
