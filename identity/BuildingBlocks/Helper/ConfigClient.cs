using System;
using System.Net;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBusRabbitMQ;
using RabbitMQ.Client;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus;
using Autofac;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.AspNetCore.Builder;

namespace TingSystem.BuildingBlocks.Helper
{
    /// <summary>
    /// Thông tin cấu hình về Identiy
    /// </summary>
    public class IdentityConfiguration
    {
        public string JwtIssuer { get;  set; }
        public string JwtAudience { get;  set; }
        public double JwtExpireDays { get; set; }
        public string JwtKey { get; set; }
        public string AuthenticationProviderKey { get; set; }
    }
    public class ConfigClient
    {       
        /// <summary>
        /// Chứa toàn bộ cấu hình
        /// </summary>
        public dynamic Configuration;

        public string ServiceName { get; set; } = "";
        public static IdentityConfiguration IdentityCfg { get; set; }
        public Action<IServiceCollection> AddEventBusHandlerFunc { get; set; } = null;
        public Action<IApplicationBuilder> SubscribeEventBusFunc { get; set; } = null;
        public void GetSettingFromServer(string UrlServerConfig)
        {
            try
            {
                var tClient = new WebClient();
                tClient.Headers.Add("Content-Type", "application/json");
                var dataJsonArray = tClient.DownloadData(String.Format("{0}/setting/{1}", UrlServerConfig, ServiceName));
                string jsonContent = Encoding.ASCII.GetString(dataJsonArray);
                Configuration = JsonConvert.DeserializeObject<dynamic>(jsonContent);
                //File.WriteAllText("config.json", jsonContent);
                
            }
            catch (System.Exception e)
            {
                throw new Exception(String.Format("Can not load config from: {0}. Error: {1}",UrlServerConfig,e.Message));
            }
        }
        /// <summary>
        /// Goi trong ham ConfigureServices cua lop Startup
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <param name="bAuthentication"></param>
        public void ConfigureServices<T>(IServiceCollection services, bool bAuthentication = true) where T : DbContext
        {
            string s = Configuration["Services"]["ConnectionStrings"]["SQLConnection"];
            // ===== Add Context ========
            services.AddDbContext<T>(
                options => options.UseSqlServer(s)
               );
            // ===== Add Jwt Authentication ========
            if (bAuthentication) ConfigureJwtAuthentication(services);
            // ===== Add policy role =====
            CreatePolicies(services);
            // ===== Register Event Bus =====
            ConfigureEventBus(services);
        }
        public void CreatePolicies(IServiceCollection services)
        {
            var policies = Configuration["Common"]["Policy"];
            services.AddAuthorization(options =>
            {
                foreach (var item in policies)
                {
                    string[] roles = ((string)item.Value).Split(',').Select(x => x.Trim()).ToArray();
                    string name = item.Name;
                    options.AddPolicy(name, policy =>
                        policy.RequireRole(roles));
                }
            });
        }
        #region "RabbitMQ"
        private void ConfigureEventBus(IServiceCollection services)
        {
            // khong dung den bus thi khong tao connection
            if (AddEventBusHandlerFunc == null && SubscribeEventBusFunc == null)
                return;
            var config = Configuration["Common"]["EventBus"];
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
                var factory = new ConnectionFactory()
                {
                    HostName = config["HostName"],
                    Port = Convert.ToInt32(config["Port"]),
                    UserName = config["UserName"],
                    Password = config["Password"]
                };
                int retryCount = Convert.ToInt32(config["RetryCount"]);
                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });
            RegisterEventBus(services, ServiceName);
        }
        private void RegisterEventBus(IServiceCollection services, string subscriptionClientName)
        {

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();
                var retryCount = 5;

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });
            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            // call the function that register all event handler of the service
            AddEventBusHandlerFunc?.Invoke(services);
            // create handlers for EventBus
            //services.AddTransient<HelloIntegrationEventHandler>();
            //services.AddSingleton<HelloIntegrationEventHandler>();
        }
        #endregion "RabbitMQ"

        public void ConfigureJwtAuthentication(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            var identityConfig = Configuration["Common"]["Identity"];
            IdentityCfg = new IdentityConfiguration
            {
                JwtIssuer = (string) identityConfig["JwtIssuer"],
                JwtAudience = (string) identityConfig["JwtAudience"],
                JwtKey = (string) identityConfig["JwtKey"],
                JwtExpireDays = (double) identityConfig["JwtExpireDays"],
                AuthenticationProviderKey = (string) identityConfig["AuthenticationProviderKey"]
            };
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IdentityCfg.JwtKey)),
                ValidIssuer = IdentityCfg.JwtIssuer,
                ValidAudience = IdentityCfg.JwtAudience,
                ClockSkew = TimeSpan.Zero, // remove delay of token when expire
                RequireExpirationTime = true
            };           
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = IdentityCfg.AuthenticationProviderKey;
                })
                //ep kieu ve string hoặc dung ham ToString?
                .AddJwtBearer(IdentityCfg.AuthenticationProviderKey, cfg =>
               {
                   cfg.RequireHttpsMetadata = false;
                   cfg.SaveToken = true;
                   cfg.TokenValidationParameters = tokenValidationParameters;
               });
        }

    }

}