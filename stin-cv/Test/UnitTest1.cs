using stincv.Controllers;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {

        PaymentController controller = new PaymentController();
        [TestMethod]
        public void TestHelloWorld()
        {
            var result = controller.Hello();
            Assert.AreEqual("Hello World", result.Value);
        }
    }
}