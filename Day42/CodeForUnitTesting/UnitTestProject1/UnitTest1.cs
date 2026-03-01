using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculatorService;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Calculator calcObj = null;
        public UnitTest1()
        {
            calcObj = new Calculator();
        }
        [TestMethod]
        public void TestMethodForAddMe()
        {
            int numTest1 = 45;
            int numTest2 = 45;
            int actual = 0;
            int expected = 90;
            actual = calcObj.Addme(numTest1, numTest2);

            Assert.AreEqual(expected, actual);
        }
    }
}