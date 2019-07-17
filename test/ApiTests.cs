using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Net;
using System;
using Xunit;
using www;

namespace test
{
    public class ApiTests
    {
        [Fact]
        public async Task CanCallApi()
        {
            CancellationTokenSource cancel = new CancellationTokenSource();
            var server = new ApiServer(8080).RunAsync(cancel.Token);
            await Task.Delay(1000);
            if (server.IsFaulted) {
                throw server.Exception;
            }

            var request = HttpWebRequest.CreateHttp("http://localhost:8080/stuff");
            request.Method = HttpMethod.Get.Method;
            var response = (HttpWebResponse) request.GetResponse();
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            cancel.Cancel();
            await server;
        }
    }
}
