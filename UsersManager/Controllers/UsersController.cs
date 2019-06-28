using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostManager.Common.Models;

namespace UsersManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<FeedResponse> GetFeed([FromBody]string userId)
        {
            return new FeedResponse();
        }
    }
}
