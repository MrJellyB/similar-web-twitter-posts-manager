using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PostManager.Common.Middlewares;
using UsersManager.Logic;

namespace UsersManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpClient();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = TokenValidationHandler.SchemeName;
            }).AddScheme<CustomAuthOptions, TokenValidationHandler>(TokenValidationHandler.SchemeName, "My Scheme", (options) => { });

            services.AddHttpContextAccessor();

            services.AddHttpClient("withToken", c =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var contextAccessor = serviceProvider.GetService<IHttpContextAccessor>();

                var token = contextAccessor.HttpContext.Request.Headers["token"].FirstOrDefault();

                if (token != null)
                    c.DefaultRequestHeaders.Add("token", token);
            });

            services.AddSingleton<IUsersRepository, UsersRepository>();
            services.AddSingleton<IFeedRepository, FeedRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<IFeedUserEnricher, FeedUserEnricher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseMvc();
        }
    }
}
