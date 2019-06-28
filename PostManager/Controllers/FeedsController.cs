using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostManager.BL.Services;
using PostManager.Common.Exceptions;
using PostManager.Common.Models;
using PostManager.Middlewares;
using Microsoft.AspNetCore.Authorization;

namespace PostManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = TokenValidationHandler.SchemeName)]
    public class FeedsController : ControllerBase
    {
        private readonly IFeedsService _feedsService;

        public FeedsController(IFeedsService feedsService)
        {
            _feedsService = feedsService;
        }

        public async Task<IActionResult> Create([FromBody]CreateFeedRequest request)
        {
            try
            {
                await _feedsService.CreateFeed(request);

            }
            catch (MoreThanOneFeedForUserException)
            {
                return BadRequest("Allowed only one feed for one user, this user already have one");
                throw;
            }

            return Ok();
        }
    }
}