﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Reviews.Api.Data.DataContexts;
using Reviews.Api.Data.Stores;

namespace Reviews.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ClientPolicy", p => p.RequireClaim("client_ClientType"));
            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            ReviewsDataContext dataCtx = new ReviewsDataContext(Configuration.GetConnectionString("ReviewsDataStore"));
            services.AddSingleton(dataCtx);
            //ReviewsStoreMongo store = new ReviewsStoreMongo(dataCtx);
            //services.AddSingleton(store);
            services.AddSingleton<IReviewsStore, ReviewsStoreMongo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:6060",
                RequireHttpsMetadata = false,
                ApiName = "reviews.api"
            });

            app.UseMvc();
        }
    }
}
