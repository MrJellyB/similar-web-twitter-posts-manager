using System.ComponentModel.DataAnnotations;

namespace PostManager.Models
{
    public class Post
    {
        [Required]
        public string Title { get; set; }

        public string Body { get; set; }
    }
}
