﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Application.Commands.Delete;
using DataAccess;
using EFCommands;

using Application.Commands.Categories;
using Application.Commands.Genders;
using Application.Commands.Journalists;
using Application.Commands.Logs;
using Application.Commands.Roles;
using Application.Commands.Stories;
using Application.Commands.Users;

using EFCommands.Categories;
using EFCommands.Genders;
using EFCommands.Journalists;
using EFCommands.Logs;
using EFCommands.Roles;
using EFCommands.Stories;
using EFCommands.Users;
using Api.Email;
using Application.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
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
            services.AddDbContext<Context>();

            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IDeleteGenderCommand, EfDeleteGenderCommand>();
            services.AddTransient<IDeleteJournalistCommand, EfDeleteJournalistCommand>();
            services.AddTransient<IDeleteLogCommand, EfDeleteLogCommand>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
            services.AddTransient<IDeleteStoryCommand, EfDeleteStoryCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            
            services.AddTransient<IGetCategoryCommand, EfGetCategoryCommand>();
            services.AddTransient<IGetGenderCommand, EfGetGenderCommand>();
            services.AddTransient<IGetJournalistCommand, EfGetJournalistCommand>();
            services.AddTransient<IGetLogCommand, EfGetLogCommand>();
            services.AddTransient<IGetRoleCommand, EfGetRoleCommand>();
            services.AddTransient<IGetStoryCommand, EfGetStoryCommand>();
            services.AddTransient<IGetUserCommand, EfGetUserCommand>();

            services.AddTransient<IGetCategoriesCommand, EfGetCategoriesCommand>();
            services.AddTransient<IGetGendersCommand, EfGetGendersCommand>();
            services.AddTransient<IGetJournalistsCommand, EfGetJournalistsCommand>();
            services.AddTransient<IGetLogsCommand, EfGetLogsCommand>();
            services.AddTransient<IGetRolesCommand, EfGetRolesCommand>();
            services.AddTransient<IGetStoriesCommand, EfGetStoriesCommand>();
            services.AddTransient<IGetUsersCommand, EfGetUsersCommand>();

            services.AddTransient<IInsertCategoryCommand, EfInsertCategoryCommand>();
            services.AddTransient<IInsertGenderCommand, EfInsertGenderCommand>();
            services.AddTransient<IInsertJournalistCommand, EfInsertJournalistCommand>();
            services.AddTransient<IInsertLogCommand, EfInsertLogCommand>();
            services.AddTransient<IInsertRoleCommand, EfInsertRoleCommand>();
            services.AddTransient<IInsertStoryCommand, EfInsertStoryCommand>();
            services.AddTransient<IInsertUserCommand, EfInsertUserCommand>();

            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<IUpdateGenderCommand, EfUpdateGenderCommand>();
            services.AddTransient<IUpdateJournalistCommand, EfUpdateJournalistCommand>();
            services.AddTransient<IUpdateLogCommand, EfUpdateLogCommand>();
            services.AddTransient<IUpdateRoleCommand, EfUpdateRoleCommand>();
            services.AddTransient<IUpdateStoryCommand, EfUpdateStoryCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();

            var section = Configuration.GetSection("Email");

            var sender =
                new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["fromaddress"], section["password"]);

            services.AddSingleton<IEmailSender>(sender);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Info News Api", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
