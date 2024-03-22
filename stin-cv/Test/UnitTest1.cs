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
            var response = paymentController.Hello();
            Assert.AreEqual("Hello World", response);
        }

        [TestMethod]
        public void TestTime()
        {
            var response = paymentController.Time();
            Assert.AreEqual(DateTime.Now.ToString(), response.Value);
        }

        [TestMethod]
        public void TestProcessPayment1()
        {
            string json = File.ReadAllText("E:\\+TUL\\4_semestr\\STIN\\cviceni\\stin-cv\\Test\\TestData\\test1.json");
            PaymentVM paymentVM = JsonSerializer.Deserialize<PaymentVM>(json);
            var response = paymentController.ProcessPayment(paymentVM);
            Assert.AreEqual("999/EUR", response.Value);
        }
        [TestMethod]
        public void TestProcessPayment2()
        {
            string json = File.ReadAllText("E:\\+TUL\\4_semestr\\STIN\\cviceni\\stin-cv\\Test\\TestData\\test2.json");
            PaymentVM paymentVM = JsonSerializer.Deserialize<PaymentVM>(json);
            var response = paymentController.ProcessPayment(paymentVM);
            string xmlOutput = "<Payment><Amount>1000</Amount><Currency>CZK</Currency><Date>2021-11-10</Date><PaymentType>CASH</PaymentType></Payment>";
            Assert.AreEqual(xmlOutput, response.Value);
        }

        [TestMethod]
        public void TestProcessPayment3()
        {
            string json = File.ReadAllText("E:\\+TUL\\4_semestr\\STIN\\cviceni\\stin-cv\\Test\\TestData\\test3.json");
            PaymentVM paymentVM = JsonSerializer.Deserialize<PaymentVM>(json);
            var response = paymentController.ProcessPayment(paymentVM);
            Assert.AreEqual("Internal Server Error", response.Value);
        }

    }
}