using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Xunit;
using alternate;
using real;

namespace test
{
    public class ApiTests
    {
        [Fact]
        public async Task CanGetFakeStuffFromApi()
        {
            var fakeStuffHolder = new InMemoryStuffHolder();
            var testServer = await ApiTestServer.StartNew(fakeStuffHolder);

            var responseBody = GetStuffFromApi(testServer.baseUrl);

            Assert.Contains("fake stuff", responseBody);

            await testServer.Stop();
        }

        [Fact]
        public async Task CanGetRealStuffFromApi()
        {
            var realStuffHolder = new RealStuffHolder("real stuff", TimeSpan.Zero);
            var testServer = await ApiTestServer.StartNew(realStuffHolder);

            var responseBody = GetStuffFromApi(testServer.baseUrl);
            
            Assert.Contains("real stuff", responseBody);

            await testServer.Stop();
        }

        private static string GetStuffFromApi(string baseUrl)
        {
            var request = HttpWebRequest.CreateHttp($"{baseUrl}/stuff");
            request.Method = HttpMethod.Get.Method;

            var response = (HttpWebResponse)request.GetResponse();
            var responseBodyStream = new StreamReader(response.GetResponseStream());
            var responseBody = responseBodyStream.ReadToEnd();

            return responseBody;
        }

    }
}
