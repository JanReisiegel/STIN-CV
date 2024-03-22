using stincv.Controllers;
using System.Net.Http.Headers;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly HttpClient _client;

        public UnitTest1()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5037"),
                DefaultRequestHeaders =
                {
                    Accept = { new MediaTypeWithQualityHeaderValue("application/json") }
                }
            };
        }

        [TestMethod]
        public async void TestHelloWorld()
        {
            var response = await _client.GetAsync("/api/Payment/");
            Assert.IsTrue(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Assert.AreEqual("Hello World", responseString);
            }
        }


    }
}