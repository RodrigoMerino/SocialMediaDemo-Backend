using AutoMapper;
using Core.Interfaces;
using Core.Services;
using FluentValidation.AspNetCore;
using Infraestructure.Data;
using Infraestructure.Filters;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //para evitar el looping en entityframe
            services.AddControllers( options => 
            {
                options.Filters.Add<GlobalValidationFilter>(); 
                }).AddNewtonsoftJson(options => 
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<SocialMediaContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("TestConnection")));
            //Macheamos la interface con el repo para que nos coja la interfaz.
            services.AddTransient<IPostService, PostService>();
            // services.AddTransient<IPostInterface, PostRepository>();
            //ervices.AddTransient<IUserRepository, UserRepository>();
           services.AddScoped( typeof(IBaseRepository<>), typeof( BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWorkRepository>();

            services.AddMvc(options =>
            {//Filter default mvc, use with fluent api
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
