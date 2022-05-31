using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using IdentityServer.Identity;

namespace Server.Identity
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(
                builder => {
                    builder.UseStartup<Startup>();
                });

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}