using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EulerLibrary;
using System.Linq;

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
            Assert.AreEqual(false, MathLibrary.IsMultiple(37, 66));
        }
    }

    [TestClass]
    public class SimpleMath
    {
        [TestMethod]
        public void Square()
        {
            Assert.AreEqual(0, MathLibrary.Square(0));
            Assert.AreEqual(1, MathLibrary.Square(-1));
            Assert.AreEqual(25, MathLibrary.Square(5));
        }

        [TestMethod]
        public void NaturalSum()
        {
            Assert.AreEqual(55, MathLibrary.SumNatural(10));
            Assert.AreEqual(0, MathLibrary.SumNatural(0));
            Assert.AreEqual(0, MathLibrary.SumNatural(-10));
        }

        [TestMethod]
        public void NaturalSumSquare()
        {
            Assert.AreEqual(385, MathLibrary.SumNaturalSquares(10));
            Assert.AreEqual(0, MathLibrary.SumNaturalSquares(0));
            Assert.AreEqual(0, MathLibrary.SumNaturalSquares(-10));
        }

        [TestMethod]
        public void TestGetPrime()
        {
            List<long> actual = MathLibrary.GetPrime(20);
            List<long> expected = new List<long> { 2, 3, 5, 7, 11, 13, 17, 19 };
            Assert.AreEqual(expected[5], actual[5]);

            actual = MathLibrary.GetPrime(23);
            Assert.AreEqual(9, actual.Count);

            actual = MathLibrary.GetPrime(7920);
            Assert.AreEqual(1000, actual.Count);
            Assert.AreEqual(7919, actual[^1]);
        }

        [TestMethod]
        public void TestSeriesProduct()
        {
            List<long> numbers = new List<long> { 2, 3, 4, 5 };
            Assert.AreEqual(120, MathLibrary.SeriesProduct(numbers));
            numbers = new List<long> { 0, 999, 33, -1, 10 };
            Assert.AreEqual(0, MathLibrary.SeriesProduct(numbers));
            numbers = new List<long> { 9, 9, 8, 9 };
            Assert.AreEqual(5832, MathLibrary.SeriesProduct(numbers));
        }

        [TestMethod]
        public void TestSeriesSum()
        {
            List<long> numbers = new List<long> { 2, 3, 5, 7 };
            Assert.AreEqual(17, MathLibrary.SeriesSum(numbers));
        }

        [TestMethod]
        public void TestGetDivisors()
        {
            List<long> divisors = MathLibrary.GetDivisors(1);
            Assert.IsTrue( divisors[0] == 1 );
            divisors = MathLibrary.GetDivisors(3);
            Assert.IsTrue(divisors[0] == 1 && divisors[1] == 3);
            divisors = MathLibrary.GetDivisors(28);
            Assert.IsTrue(divisors.Contains(1) &&
                          divisors.Contains(2) &&
                          divisors.Contains(4) &&
                          divisors.Contains(7) &&
                          divisors.Contains(14) &&
                          divisors.Contains(28));
        }
    }
}
