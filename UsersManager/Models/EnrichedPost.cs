using PostManager.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersManager.Models
{
    public class EnrichedPost
    {
        public PostResponse OriginalPost { get; set; }
        public User Owner { get; set; }
    }
}
