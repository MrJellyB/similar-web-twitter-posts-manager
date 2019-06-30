using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostManager.DAL.Contexts;
using PostManager.DAL.Services;
using System;

namespace PostManager.BL.Startup
{
    public static class ServiceRegistrationExtension
    {

        public static void AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (connectionString == null)
                connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

            services.AddDbContext<FeedContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IPostsRepository, PostsRepository>();
            services.AddScoped<IFeedsRepository, FeedsRepository>();

        }
    }
}
