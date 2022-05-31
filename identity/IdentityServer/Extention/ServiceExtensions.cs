using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Services;
using Server.Identity.Configuration;
using IdentityServer.Identity;
using System.Reflection;
using Base.Models;
using IdentityConfigurationSample.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Server.Identity.Extention
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            //services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

        }

        public static void AllowCORS(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void AddIdentityServer4(this IServiceCollection services, string connectionString)
        {
            string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            //services.Configure<IdentityOptions>(options => {
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequireDigit = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //});

            services.AddControllers().AddNewtonsoftJson(
                options =>
                {
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                });
            // services.AddTransient<IProfileService, ProfileService>();
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
             .AddInMemoryPersistedGrants()
             .AddInMemoryIdentityResources(Config.GetIdentityResources())
             .AddInMemoryApiResources(Config.GetApiResources())
             .AddInMemoryApiScopes(Config.GetApiScope())
             .AddInMemoryClients(Config.GetClients())

             .AddConfigurationStore(options =>
             {
                 options.ConfigureDbContext = builder =>
                    builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), sql => sql.MigrationsAssembly(migrationsAssembly));
             })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = builder =>
                    builder.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString), sql => sql.MigrationsAssembly(migrationsAssembly));

                 // this enables automatic token cleanup. this is optional.
                 options.EnableTokenCleanup = true;
                options.TokenCleanupInterval = 30;
            })

            //.AddTestUsers(Config.GetTestUsers());
            .AddAspNetIdentity<IdentityUser>();
            //.AddProfileService<ProfileService>();

        }

        public static void CreatePolicies(this IServiceCollection services)
        {
            //string[] NameOfRSVNApis = { "NewRSVN", "GetRSVNs", "GetRSVN", "GetRSVNByRSVNCode",
            //"GetReservatedRoomCountsByRoomType", "SetBookerByPhoneAsync", "SetBookerByEmailAsync",
            //"SetBookerByFaxAsync", "DeleteRSVN" };
            //string[] NameOfRSVNServices = {"GetPickup", "PostPickupAsync", "SetPickup",
            //"DeletePickup", "GetFlight", "CreateFlightAsync", "SetFlight", "DeleteFlight"};
            //string[] NameOfTransactRoomApis = { "GetTransactRooms", "GetTransactRoom", "NewTransactRoom", "DeleteTransactRoom", "UpdateTransactRoom" };
            //services.AddAuthorization(options => {
            //    foreach (var item in NameOfRSVNApis) {
            //        options.AddPolicy(item, policy =>
            //        policy.RequireClaim(ClaimTypes.Name, item));
            //    }

            //    foreach (var item in NameOfRSVNServices) {
            //        options.AddPolicy(item, policy =>
            //        policy.RequireClaim(ClaimTypes.Name, item));
            //    }

            //    foreach (var item in NameOfTransactRoomApis) {
            //        options.AddPolicy(item, policy =>
            //        policy.RequireClaim(ClaimTypes.Name, item));
            //    }
            //});
        }
    }
}