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

    [TestClass]
    public class IsMultiples
    { 
        [TestMethod]
        public void PassMultiples()
        {
            Assert.AreEqual(true, MathLibrary.IsMultiple(4, 2));
            Assert.AreEqual(true, MathLibrary.IsMultiple(9, 3));
            Assert.AreEqual(true, MathLibrary.IsMultiple(12, 6));
            Assert.AreEqual(true, MathLibrary.IsMultiple(25, 5));
            Assert.AreEqual(true, MathLibrary.IsMultiple(4648, 332));
            Assert.AreEqual(true, MathLibrary.IsMultiple(2, 1));
        }

        [TestMethod]
        public void FailMultiples()
        {
            Assert.AreEqual(false, MathLibrary.IsMultiple(4, 3));
            Assert.AreEqual(false, MathLibrary.IsMultiple(1, 0));
            Assert.AreEqual(false, MathLibrary.IsMultiple(13, 3));
            Assert.AreEqual(false, MathLibrary.IsMultiple(19, 18));
            Assert.AreEqual(false, MathLibrary.IsMultiple(23, 2));
            Assert.AreEqual(false, MathLibrary.IsMultiple(37, 6));
        }
    }
}
