using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GameStoreApp.Extensao;

namespace GameStoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //criamos o método de extensão CreateAdminRole
            CreateHostBuilder(args)
               .Build()
               .CreateAdminRole()
               .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
