using AppNet6.Core.CustionEntities;
using AppNet6.Infrestructuras.Data;
using AppNet6.Infrestructuras.Interfaces;
using AppNet6.Infrestructuras.Options;
using AppNet6.Infrestructuras.Repositories;
using AppNet6.Infrestructuras.Services;
using AppNet6.Negocios.Interfaces;
using AppNet6.Negocios.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AppNet6.Negocios.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppContextBD>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CNSQL"));
            });
        }

        public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(configuration.GetSection("Pagination"));
            services.Configure<PasswordOptions>(configuration.GetSection("PasswordOptions"));
            //services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            //services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));
            //return services;
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
            services.AddSingleton<IUrlService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var requet = accesor.HttpContext.Request;
                var absoluteUrl = string.Concat(requet.Scheme, "://", requet.Host.ToUriComponent());
                return new UrlService(absoluteUrl);
            });
        }
        public static void AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Authentication:Issuer"],
                    ValidAudience = configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]))
                };
              
            });
        }


    }
}
