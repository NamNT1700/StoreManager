﻿using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Entities;
using Repository;
using Store;

namespace StoreManager.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders("Location"));
            });

        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<RepositoryContext>
                (o => o.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion));
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        //    services.AddSingleton<IRepositoryWrapper, RepositoryWrapper>();
        //    services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
        //    services.AddScoped<IAccountRepository, AccountRepository>();
        //    services.AddSingleton<Contracts.IOwnerRepository, Contracts.IOwnerRepository>();
        
        }
    }
}
