using System.Threading;
using System.Threading.Tasks;
using core;
using www;

namespace test
{
    public class ApiTestServer
    {
        public const int port = 8080;
        public readonly string baseUrl = $"http://localhost:{port}";

        private CancellationTokenSource cancel;
        private ApiServer apiServer;
        private Task serverTask;

        public ApiTestServer(IStuffHolder stuffHolder) {
            cancel = new CancellationTokenSource();
            apiServer = new ApiServer(port, stuffHolder);
        }

        public async Task Start() {
            serverTask = apiServer.RunAsync(cancel.Token);
            await Task.Delay(1000);
            if (serverTask.IsFaulted) {
                throw serverTask.Exception;
            }
        }

        public async Task Stop() {
            cancel.Cancel();
            await this.serverTask;
        }

        public async static Task<ApiTestServer> StartNew(IStuffHolder stuffHolder)
        {
            var testServer = new ApiTestServer(stuffHolder);
            await testServer.Start();
            return testServer;
        }
    }
}