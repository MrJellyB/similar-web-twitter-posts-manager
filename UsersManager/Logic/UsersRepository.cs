using AutoMapper;
using Newtonsoft.Json;
using PostManager.Common.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using UsersManager.Models;

namespace UsersManager.Logic
{

    public interface IUsersRepository
    {
        void Add(User user, string userId);
        Task<User> Fetch(string userId);
    }

    public class UsersRepository : BaseRepository, IUsersRepository, IValueResolver<FeedResponse, EnrichedFeed, EnrichedPost[]>
    {
        public UsersRepository(IHttpClientFactory factory): base(factory)
        {
            UsersList = new Dictionary<string, User>();
        }

        public Dictionary<string, User> UsersList { get; private set; }

        public async Task<User> Fetch(string userId)
        {
            if (userId == null)
                return null;

            UsersList.TryGetValue(userId, out var cachedUser);

            if (cachedUser != null)
                return cachedUser;

            using (var httpClient = _httpClientFactory.CreateClient("withToken"))
            {
                var authServiceUrl = Environment.GetEnvironmentVariable("MICROSERVICES_AUTH");
                var userResponse = await
                    (await httpClient.GetAsync($"{authServiceUrl}/info/user?userId={userId}")).Content.ReadAsStringAsync();

                var user = JsonConvert.DeserializeObject<User>(userResponse);

                UsersList.Add(userId, user);

                return user;
            }
        }

        public void Add(User user, string userId)
        {
            try
            {
                lock (UsersList)
                {
                    UsersList.Add(userId, user);
                }
            }
            catch (ArgumentException)
            {

            }
        }

        public EnrichedPost[] Resolve(FeedResponse source, EnrichedFeed destination, EnrichedPost[] destMember, ResolutionContext context)
        {
           var results =  
                source.Posts
                .Select(async post => new EnrichedPost() {
                    OriginalPost = post,
                    Owner = await Fetch(post.User) })
                .Select(t => t.Result)
                .ToArray();

            return results;
        }
    }
}
