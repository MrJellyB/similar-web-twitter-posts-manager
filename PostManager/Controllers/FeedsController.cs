using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostManager.BL.Services;
using PostManager.Common.Exceptions;
using PostManager.Common.Models;

namespace PostManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedsController : ControllerBase
    {
        private readonly IFeedsService _feedsService;

        public FeedsController(IFeedsService feedsService)
        {
            _feedsService = feedsService;
        }

        public async Task<IActionResult> Create(CreateFeedRequest request)
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