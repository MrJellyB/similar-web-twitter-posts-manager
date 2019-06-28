using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UsersManager.Logic
{
    public class UserData
    {
        public string FullName { get; set; }
    }

    public class User
    {
        private readonly IHttpClientFactory _httpFactory;
        private UserData data;

        public User(IHttpClientFactory factory)
        {
            _httpFactory = factory;
        }

        public async Task FetchData(string userId)
        {
            using (var httpClient = _httpFactory.CreateClient())
            {
                var authMicroserviceUrl = Environment.GetEnvironmentVariable("MICROSERVICES_AUTH");

                var clientDetailsResponse = await httpClient.GetAsync($"{authMicroserviceUrl}/info/user?userId={userId}");

                var clientDetails = await clientDetailsResponse.Content.ReadAsStringAsync();
                data = new UserData { FullName = clientDetails };
            }
        }
    }

    public interface IUsers
    {
        void Add(User user, string userId);
    }

    public class Users : IUsers
    {
        public Dictionary<string, User> UsersList { get; private set; }

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
