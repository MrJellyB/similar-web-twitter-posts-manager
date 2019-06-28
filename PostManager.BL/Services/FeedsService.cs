using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostManager.Common.Exceptions;
using PostManager.Common.Models;
using PostManager.DAL.Entities;
using PostManager.DAL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostManager.BL.Services
{
    public interface IFeedsService
    {
        Task CreateFeed(CreateFeedRequest request);
    }

    public class FeedsService : IFeedsService
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

            _repository.Create(feedToSave);

            try
            {
                await _repository.SaveChangesAsync();

            }
            catch (DbUpdateException e)
            {
                if (e.InnerException.Message.Contains("23505"))
                    throw new MoreThanOneFeedForUserException();

                throw;
            }

        }
    }
}
