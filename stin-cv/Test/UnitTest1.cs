using stincv.Controllers;

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
                BaseAddress = new Uri("https://localhost:7181")
            };
        }

        [TestMethod]
        public void TestHelloWorld()
        {
            var response = _client.GetAsync(_client.BaseAddress + "api/Payment/hello").Result;
            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.AreEqual("Hello World", response.Content.ReadAsStringAsync().Result);
        }


    }
}