using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostManager.BL.OnMemoryStore;
using PostManager.BL.Services;

namespace PostManager.BL.Startup
{
    public static class ServiceRegistrationExtension
    {
        public static void AddBLServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALServices(configuration);

            services.AddScoped<IPostsService, PostsService>();
            services.AddScoped<IFeedsService, FeedsService>();
            services.AddSingleton<IUsers, Users>();
        }
    }
}
