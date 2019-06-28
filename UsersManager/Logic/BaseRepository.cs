using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UsersManager.Logic
{
    public abstract class BaseRepository
    {
        protected readonly IHttpClientFactory _httpClientFactory;

        public BaseRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
