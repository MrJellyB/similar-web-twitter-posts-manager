using System;
using System.Collections.Generic;
using System.Text;

namespace PostManager.Common.Models
{
    public class PostResponse
    {
        public string Title { get; set; }

        public virtual string User { get; set; }

        public string Body { get; set; }

        public int Id { get; set; }
    }
}
