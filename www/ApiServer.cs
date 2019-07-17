using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace www
{
    public class ApiServer
    {
        public ApiServer(int port) {

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
                })
                .Configure(appBuilder => {
                    appBuilder.UseMvcWithDefaultRoute();
                });
    }
}