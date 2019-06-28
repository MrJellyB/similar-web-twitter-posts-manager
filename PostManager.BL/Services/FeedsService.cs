using AutoMapper;
using PostManager.Common.Models;
using PostManager.DAL.Entities;
using PostManager.DAL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.BL.Services
{
    public class FeedsService
    {
        private readonly IMapper _mapper;
        private readonly IFeedsRepository _repository;

        public FeedsService(IMapper mapper, IFeedsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateFeed(CreateFeedRequest request)
        {
            var feedToSave = _mapper.Map<Feed>(request);

            _repository.CreateFeed(feedToSave);

            await _repository.SaveChangesAsync();
        }
    }
}
