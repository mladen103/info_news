using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Application.Commands.Journalists;
using DataAccess;
using EFCommands;
using EFCommands.Journalists;
using EFCommands.Stories;
using Application.Commands.Stories;

namespace WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<Context>();

            services.AddTransient<IDeleteJournalistCommand, EfDeleteJournalistCommand>();
            services.AddTransient<IGetJournalistCommand, EfGetJournalistCommand>();
            services.AddTransient<IGetJournalistsCommand, EfGetJournalistsCommand>();
            services.AddTransient<IInsertJournalistCommand, EfInsertJournalistCommand>();
            services.AddTransient<IUpdateJournalistCommand, EfUpdateJournalistCommand>();

            services.AddTransient<IGetStoriesCommand, EfGetStoriesCommand>();
            services.AddTransient<IInsertStoryCommand, EfInsertStoryCommand>();
            services.AddTransient<IUpdateStoryCommand, EfUpdateStoryCommand>();
            services.AddTransient<IGetStoryCommand, EfGetStoryCommand>();
            services.AddTransient<IDeleteStoryCommand, EfDeleteStoryCommand>();

            services.AddTransient<IGetJournalistsCommand, EfGetJournalistsCommand>();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
