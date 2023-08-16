using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using outer_space.Data;

namespace outer_space.Web
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
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddOptions();

            //Connect to the portion of the database that has ASP.NET Core Identity data...
            //TODO: Figure out connection pooling (AddDbContextPool)

            //services.AddDbContext<AppIdentityDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<AppUserModels, IdentityRole>()
            //    .AddEntityFrameworkStores<AppIdentityDbContext>()  //EF Core
            //    .AddDefaultTokenProviders()
            //    .AddDefaultUI(); //Gives you forms for registering, logging in, etc.

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.User.RequireUniqueEmail = true;
            //});

            //Connect to the rest of the database...
            //TODO: Figure out connection pooling (AddDbContextPool)

            services.AddDbContext<DataModelDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //Base Services...
            //...

            //Joint Services...
            //...

            //Worker Services...
            //...
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //    app.UseDeveloperExceptionPage();
            //else
            //    app.UseExceptionHandler("/Error");

            //app.UseHsts(); //The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseAuthentication(); //ASP.NET authentication users/roles
            //app.UseCookiePolicy();

            //app.UseRouting();
            //app.UseAuthorization(); //ASP.NET authentication users/roles (need this line also)
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});
        }
    }
}