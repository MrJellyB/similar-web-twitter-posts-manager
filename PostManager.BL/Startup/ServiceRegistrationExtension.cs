using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostManager.BL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostManager.BL.Startup
{
    public static class ServiceRegistrationExtension
    {
        public static void AddBLServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALServices(configuration);

            services.AddScoped<IPostsService, PostsService>();
        }
    }
}
