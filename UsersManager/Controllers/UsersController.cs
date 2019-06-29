using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostManager.Common.Models;
using UsersManager.Logic;
using UsersManager.Models;

namespace UsersManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IFeedUserEnricher _feedUserEnricher;
        private readonly IFeedRepository _feedRepository;

        public UsersController(IFeedUserEnricher feedUserEnricher, IFeedRepository feedRepository)
        {
            _feedUserEnricher = feedUserEnricher;
            _feedRepository = feedRepository;
        }

        [HttpGet]
        [Route("feed")]
        public async Task<EnrichedFeed> GetFeed([FromQuery]string userId)
        {
            var feed = await _feedRepository.Fetch(userId);
            var enriched = _feedUserEnricher.Enrich(feed);

            return enriched;
        }
    }
}
