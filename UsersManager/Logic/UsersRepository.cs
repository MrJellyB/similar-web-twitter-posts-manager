using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UsersManager.Models;

namespace UsersManager.Logic
{

    public interface IUsersRepository
    {
        void Add(User user, string userId);
        Task<User> Fetch(string userId);
    }

    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public UsersRepository(IHttpClientFactory factory): base(factory)
        {

        }

        public Dictionary<string, User> UsersList { get; private set; }

        public async Task<User> Fetch(string userId)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var authServiceUrl = Environment.GetEnvironmentVariable("MICROSERVICES_AUTH");
                var userResponse = await
                    (await httpClient.GetAsync(authServiceUrl)).Content.ReadAsStringAsync();

                var user = JsonConvert.DeserializeObject<User>(userResponse);

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
    }
}
