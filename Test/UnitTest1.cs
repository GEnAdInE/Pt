using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicExemple;



namespace Test
{
    [TestClass]
    public class TestOperation
    {
        private const int expected = 10;
        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(expected, Operation.Add(4, 6));
        }

        [TestMethod]
        public void TestMinus()
        {
            Assert.AreEqual(expected, Operation.Minus(18, 8));
        }

    }
}