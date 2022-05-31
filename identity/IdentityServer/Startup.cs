using IdentityServer4.AspNetIdentity;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.Identity.Configuration;
using Server.Identity.Extention;
using System.Globalization;
using System.Linq;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityConfigurationSample.Data;

namespace IdentityServer.Identity
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json", true, true)
             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
             .AddEnvironmentVariables();
            Configuration = builder.Build();
            //Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("Connection");
        //    services.AddAutoMapper(typeof(Startup));
            //Add database Context
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("Server.Identity")));
            // config Wrapper
            //services.ConfigureRepositoryWrapper();
            // Add Identitys4
            //services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryPersistedGrants()
            //    .AddInMemoryIdentityResources(Config.GetIdentityResources())
            //    .AddInMemoryApiResources(Config.GetApiResources())
            //    .AddInMemoryClients(Config.GetClients())
            //    .AddAspNetIdentity<IdentityUser>();
            services.AddIdentityServer4(connectionString);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeDatabase(app);
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestLocalization(new RequestLocalizationOptions() {
                DefaultRequestCulture = new RequestCulture("en"),
                SupportedCultures = new[] { new CultureInfo("en"), new CultureInfo("vi") },
                SupportedUICultures = new[] { new CultureInfo("en"), new CultureInfo("vi") },
                RequestCultureProviders = new IRequestCultureProvider[] {
                    new QueryStringRequestCultureProvider(),
                    new AcceptLanguageHeaderRequestCultureProvider()
                },
            });
       // C: \Users\Tuan Nam\Downloads\Compressed\identity\IdentityServer\Server.Identity.csproj
            app.UseIdentityServer();

            app.UseRouting();

            app.UseEndpoints(builder => builder.MapDefaultControllerRoute());
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();

                if (context.Clients.Any()) {               
                context.Clients.RemoveRange(context.Clients);
                context.SaveChanges();
                }
                foreach (var client in Config.GetClients())
                    context.Clients.Add(client.ToEntity());
                context.SaveChanges();

                if (context.IdentityResources.Any()) {
                    context.IdentityResources.RemoveRange(context.IdentityResources);
                    context.SaveChanges();
                }
                foreach (var resource in Config.GetIdentityResources())
                    context.IdentityResources.Add(resource.ToEntity());
                context.SaveChanges();
 
                if (context.ApiResources.Any()) {
                    context.ApiResources.RemoveRange(context.ApiResources);
                    context.SaveChanges();
                }
                foreach (var resource in Config.GetApiResources())
                    context.ApiResources.Add(resource.ToEntity());
                context.SaveChanges();

                if (context.ApiScopes.Any())
                {
                    context.ApiScopes.RemoveRange(context.ApiScopes);
                    context.SaveChanges();
                }
                foreach (var resource in Config.GetApiScope())
                    context.ApiScopes.Add(resource.ToEntity());
                context.SaveChanges();
            }
        }
    }
}