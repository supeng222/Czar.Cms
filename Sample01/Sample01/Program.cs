using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Sample01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   //.ConfigureAppConfiguration((hostingContext, config) =>
                   //{
                   //    var env = hostingContext.HostingEnvironment;
                   //    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   //          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                   //          //加载自定义json文件内容
                   //          //.AddJsonFile("Captain AmericaInfo.json", optional: false, reloadOnChange: false)
                   //          //.AddEnvironmentVariables();

                   //})
                   .ConfigureAppConfiguration((hostingContext, config) => 
                   {
                       var env = hostingContext.HostingEnvironment;
                       config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                             .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)

                       //加载自定义内容
                              .AddJsonFile("CaptainAmericaInfo.json", optional: false, reloadOnChange: true)
                              .AddEnvironmentVariables();
                   })
                   .UseStartup<Startup>();
    }
}
