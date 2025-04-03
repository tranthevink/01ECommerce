using ECommerce.Application.Interfaces;
using ECommerce.Infrastructure.Persistence.Database;
using ECommerce.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ECommerce.API
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies()
                       .UseSqlServer("Server=.;Database=MyApp;Trusted_Connection=True;"));
            services.AddAuthentication(options =>
                    {
                        options.DefaultScheme = "MyCookie";
                        options.DefaultAuthenticateScheme = "MyCookie";
                        options.DefaultChallengeScheme = "MyCookie";
                    })
                    .AddCookie("MyCookie", options =>
                    {
                        options.Cookie.Name = "MyCookie";
                        options.Cookie.SameSite = SameSiteMode.Strict;
                        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                        options.Cookie.HttpOnly = true;
                        options.Cookie.IsEssential = true;
                        options.LoginPath = "/Account/Login";
                        options.LogoutPath = "/Account/Logout";
                    })
                    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                    {
                        options.Authority = "https://localhost:5001";
                        options.RequireHttpsMetadata = !_env.IsDevelopment();
                        options.Audience = "ECommerce.API";
                    });
        }

        // Cấu hình middleware pipeline
        public void Configure(IApplicationBuilder app)
        {

            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI();
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
