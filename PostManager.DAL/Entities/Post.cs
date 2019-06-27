
using PostManager.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace PostManager.DAL.Enteties
{
    public class Post
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string UserID { get; set; }

        public string Body { get; set; }

        public int FeedId { get; set; }
        public Feed Feed { get; set; }
    }
}
