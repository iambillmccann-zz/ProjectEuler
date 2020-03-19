using Microsoft.VisualStudio.TestTools.UnitTesting;
using EulerLibrary;

namespace UtilitiesTests
{
    [TestClass]
    public class ReverseDigits
    {
        [TestMethod]
        public void ReversingEvenDigits()
        {
            long expected = 4321;
            long actual = MathLibrary.ReverseDigits(1234);
            Assert.AreEqual(expected, actual, "Reversed even number of digits failed.");
        }

        [TestMethod]
        public void ReversingOddDigits()
        {
            long expected = 987654321;
            long actual = MathLibrary.ReverseDigits(123456789);
            Assert.AreEqual(expected, actual, "Reversed odd number of digits failed.");
        }
    }
}
