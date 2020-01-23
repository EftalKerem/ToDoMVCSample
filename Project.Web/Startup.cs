using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Entity.Entity;
using Project.Entity.Repositories;
using Project.Service.ToDoDataServices;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Project.Service.RestSharpServices;
using Project.Web.Controllers;

namespace Project.Web
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
            services.AddMemoryCache();
            services.AddSession();
            services.Configure<CookiePolicyOptions>(options =>
            { 
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            }); 
            services.Configure<CookieTempDataProviderOptions>(options =>
            {
                options.Cookie.IsEssential = true;
            }); 

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddSessionStateTempDataProvider()
                .AddJsonOptions(options => {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddDbContext<EntityDbContext>();
            services.AddScoped<IRepositoryAll, RepositoryAll>();
            services.AddScoped<IToDoDataService, ToDoDataService>();
            services.AddScoped<IRestSharpService, RestSharpService>();
            GlobalConfiguration.Configuration.UsePostgreSqlStorage(Configuration.GetConnectionString("HangfireConnection")); 
            services.AddHangfire(config =>
                config.UsePostgreSqlStorage(Configuration.GetConnectionString("HangfireConnection")));
            services.AddHangfireServer();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IBackgroundJobClient backgroundJobs)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHangfireServer();
            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate<HangfireController>(t => t.HangfireAction(), Cron.Minutely);
            app.UseSession();
            app.UseHttpsRedirection();
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
