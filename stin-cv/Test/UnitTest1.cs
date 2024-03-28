using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stincv.Controllers;
using stincv.ViewModels;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        PaymentController paymentController = new PaymentController();

        [TestMethod]
        public void TestHelloWorld()
        {
            var response = paymentController.Hello() as ObjectResult;
            Assert.AreEqual("Hello World", response.Value);
        }

        [TestMethod]
        public void TestTime()
        {
            var response = paymentController.Time() as ObjectResult;
            Assert.AreEqual(DateTime.Now.ToString(), response.Value);
        }

        [TestMethod]
        public void TestProcessPayment1()
        {
            string json = File.ReadAllText("../../../TestData/test1.json"); //Univerzální øešení
            //string json = File.ReadAllText("D:/TUL/4_semestr/STIN/cviceni/projekt/stin-cv/Test/TestData/test1.json"); //Laptop
            //string json = File.ReadAllText("E:/+TUL/4_semestr/STIN/cviceni/stin-cv/Test/TestData/test1.json"); //Home
            var response = paymentController.ProcessPayment(json) as ObjectResult;
            Assert.AreEqual("999/EUR", response.Value);
        }
        [TestMethod]
        public void TestProcessPayment2()
        {
            string json = File.ReadAllText("../../../TestData/test2.json");
            var response = paymentController.ProcessPayment(json) as ObjectResult;
            string xmlOutput = "<Payment><Amount>1000</Amount><Currency>CZK</Currency><Date>2021-11-10</Date><PaymentType>CASH</PaymentType></Payment>";
            Assert.AreEqual(xmlOutput, response.Value);
        }

        [TestMethod]
        public void TestProcessPayment3()
        {
            string json = File.ReadAllText("../../../TestData/test3.json");
            var response = paymentController.ProcessPayment(json) as ObjectResult;
            Assert.AreEqual(418, response.StatusCode);
        }

    }
}