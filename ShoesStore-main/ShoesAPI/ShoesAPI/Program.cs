using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShoesAPI.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ShoesStoreDBContext>();
                SeedData.Initialize(context);
            }
            host.Run();
        }

        public static IHost CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(builder =>
            {
                builder.UseStartup<Startup>();
            })
            .Build();
        }
    }
}
