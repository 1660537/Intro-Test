using IntroTest.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IntroTest.Shared;
using System;

namespace IntroTest
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
            services.AddSession(options =>
            {
                options.Cookie.Name = ".Rating.Security.Cookie";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();
            services.AddDbContext<DataContext>(option => { option.UseSqlServer(Configuration.GetConnectionString("RatingDB")); });

            services.ConfigureJwtAuthentication();
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            }) ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(Routing.HOME_NAME, Routing.HOME_TEMPLATE);
                endpoints.MapControllerRoute(Routing.LOGIN_NAME, Routing.LOGIN_TEMPLATE);
                endpoints.MapControllerRoute(Routing.RATING_NAME, Routing.RATING_TEMPLATE);
                endpoints.MapControllerRoute(Routing.RATINGRESULT_NAME, Routing.RATINGRESULT_TEMPLATE);
            });
        }
    }
}
