using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostManager.BL.Services;
using PostManager.Common.Models;
using PostManager.Middlewares;

namespace PostManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = TokenValidationHandler.SchemeName)]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]SendPostRequest postToSend)
        {
            return Ok(await _postsService.Send(postToSend));
        }

        [HttpPost]
        [Route("like")]
        public async Task<IActionResult> Like(string postId)
        {
            await _postsService.Like(postId);

            return Ok();
        }
    }
}
