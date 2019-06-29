using System.ComponentModel.DataAnnotations;

namespace PostManager.Common.Models
{
    public class SendPostRequest
    {
        public string Title { get; set; }

        public string OwnerId { get; set; }

        public string Body { get; set; }

    }
}
