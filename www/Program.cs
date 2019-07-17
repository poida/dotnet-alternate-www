using System.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace www
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(o =>
                {
                    o.Listen(new IPEndPoint(IPAddress.Any, 8080));
                })
                .ConfigureServices(serviceCollection => {
                    serviceCollection.AddMvc();
                    serviceCollection.AddRouting();
                })
                .Configure(appBuilder => {
                });
    }
}
