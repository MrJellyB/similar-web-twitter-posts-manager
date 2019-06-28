﻿
using PostManager.DAL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostManager.DAL.Entities
{
    public class Post
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Body { get; set; }

        public ICollection<Feed> Feeds { get; set; }
    }
}
