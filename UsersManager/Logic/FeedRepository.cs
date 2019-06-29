using Newtonsoft.Json;
using PostManager.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UsersManager.Models;

namespace UsersManager.Logic
{
    public interface IFeedRepository
    {
        Task<FeedResponse> Fetch(string userId); 
    }

    public class FeedRepository : BaseRepository, IFeedRepository
    {
        public FeedRepository(IHttpClientFactory factory) : base(factory)
        {

        }

        public async Task<FeedResponse> Fetch(string userId)
        {
            using (var httpClient = _httpClientFactory.CreateClient("withToken"))
            {
                var postsServiceUrl = Environment.GetEnvironmentVariable("MICROSERVICES_POSTS");
                var feedResponse = await
                    (await httpClient.GetAsync($"{postsServiceUrl}/api/feeds/global?userId={userId}")).Content.ReadAsStringAsync();

                var feed = JsonConvert.DeserializeObject<FeedResponse>(feedResponse);

                return feed;
            }
        }
    }
}
