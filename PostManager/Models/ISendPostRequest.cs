using System.ComponentModel.DataAnnotations;

namespace PostManager.Models
{
    public class SendPostRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string UserID { get; set; }

        public string Body { get; set; }

    }
}
