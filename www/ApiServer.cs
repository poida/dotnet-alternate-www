using System.Net;
using System.Threading;
using System.Threading.Tasks;
using core;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using www.Controllers;

namespace www
{
    public class ApiServer
    {
        private readonly IStuffHolder stuffHolder;

        public ApiServer(int port, IStuffHolder stuffHolder) {
            this.stuffHolder = stuffHolder;
        }

        public void Run() {
            CreateWebHostBuilder().Build().Run();
        }

        public async Task RunAsync(CancellationToken token) {
            await CreateWebHostBuilder().Build().RunAsync(token);
        }

        private IWebHostBuilder CreateWebHostBuilder() =>
            WebHost.CreateDefaultBuilder()
                .UseKestrel(o =>
                {
                    o.Listen(new IPEndPoint(IPAddress.Any, 8080));
                })
                .ConfigureServices(serviceCollection => {
                    serviceCollection.AddMvc();
                    serviceCollection.AddRouting();
                    serviceCollection.AddSingleton<IStuffHolder>(this.stuffHolder);
                })
                .Configure(appBuilder => {
                    appBuilder.UseMvcWithDefaultRoute();
                });
    }
}