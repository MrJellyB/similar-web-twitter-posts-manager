using AutoMapper;
using PostManager.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersManager.Models;

namespace UsersManager.Logic
{
    public interface IFeedUserEnricher
    {
        EnrichedFeed Enrich(FeedResponse feed);
    }

    public class FeedUserEnricher : IFeedUserEnricher
    {
        private readonly IMapper _mapper;

        public FeedUserEnricher(IMapper mapper)
        {
            _mapper = mapper;
        }

        public EnrichedFeed Enrich(FeedResponse feed)
        {
            var enrichedFeed = _mapper.Map<FeedResponse, EnrichedFeed>(feed);

            return enrichedFeed;
        }
    }
}
