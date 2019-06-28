using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostManager.DAL.Contexts;
using PostManager.DAL.Services;

namespace PostManager.BL.Startup
{
    public static class ServiceRegistrationExtension
    {

        public static void AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //services.AddTransient<IDbContextOptions, DbContextOptions>();
            //services.AddSingleton<IPostsRepositoryFactory, PostsRepositoryFactory>();
            //services.AddSingleton<IFeedContextFactory, FeedContextFactory>();

            services.AddDbContext<FeedContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IPostsRepository, PostsRepository>();

        }
    }
}
