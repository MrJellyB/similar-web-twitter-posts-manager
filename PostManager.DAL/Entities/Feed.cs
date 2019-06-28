using PostManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PostManager.DAL.Entities
{
    public class Feed
    {
        public Guid FeedId { get; set; }

        [Required]
        public string UserID { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
