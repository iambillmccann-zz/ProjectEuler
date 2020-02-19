using Microsoft.VisualStudio.TestTools.UnitTesting;
using EulerLibrary;

namespace UtilitiesTests
{
    [TestClass]
    public class FormatMilliseconds
    {
        /// <summary>
        /// The methods for testing FormatMillisconds verifies the following behaviors ...
        /// 1. When milliseconds are less than 10, they will have two leading zeros
        /// 2. When milliseconds are less than 100, they will have one leading zero
        /// 3. When seconds are less then 10, they will have one leading zero
        /// 4. When minutes are less then 10, they will have one leading zero
        /// 5. When hours are less then 10, they will have one leading zero
        /// 6. Milleseconds shall not exceeed 999
        /// 7. Seconds shall not exceed 59
        /// 8. Minutes shall not exceed 59
        /// 9. Hours more than 99 will show all significant digits
        /// </summary>
        [TestMethod]
        public void MillisecondsLessThan10()
        {
            long totalMilliseconds = 6;

            string expected = "00:00:00.006";
            string actual = Utilities.FormatMilliseconds(totalMilliseconds);

            Assert.AreEqual(expected, actual, "Milliseconds less than 10 do not have the proper leading zeros");
        }

        [TestMethod]
        public void MillsecondsLessThan100()
        {
            long totalMilliseconds = 76;

            string expected = "00:00:00.076";
            string actual = Utilities.FormatMilliseconds(totalMilliseconds);

            Assert.AreEqual(expected, actual, "Milliseconds less than 100 do not have the proper leading zeros");
        }
        [TestMethod]
        public void SecondsLessThan10()
        {
            long totalMilliseconds = 5000;

            string expected = "00:00:05.000";
            string actual = Utilities.FormatMilliseconds(totalMilliseconds);

            Assert.AreEqual(expected, actual, "Seconds less than 10 do not have the proper leading zeros");
        }

        [TestMethod]
        public void MinutesLessThan10()
        {
            long totalMilliseconds = 180000;

            string expected = "00:03:00.000";
            string actual = Utilities.FormatMilliseconds(totalMilliseconds);

            Assert.AreEqual(expected, actual, "Minutes less than 10 do not have the proper leading zeros");
        }

        [TestMethod]
        public void HoursLessThan10()
        {
            long totalMilliseconds = 7200000;

            string expected = "02:00:00.000";
            string actual = Utilities.FormatMilliseconds(totalMilliseconds);

            Assert.AreEqual(expected, actual, "Hours less than 10 do not have the proper leading zeros");
        }

        [TestMethod]
        public void MillisecondsNotMoreThan999()
        {
            long totalMilliseconds = 1000;

            string expected = "00:00:01.000";
            string actual = Utilities.FormatMilliseconds(totalMilliseconds);

            Assert.AreEqual(expected, actual, "Milliseconds shall not exceed 999");
        }

        [TestMethod]
        public void SecondsLessThan60()
        {
            long totalMilliseconds = 60000;

            string expected = "00:01:00.000";
            string actual = Utilities.FormatMilliseconds(totalMilliseconds);

            Assert.AreEqual(expected, actual, "Seconds shall not exceed 59");
        }

        [TestMethod]
        public void MinutesLessThan60()
        {
            long totalMilliseconds = 3600000;

            string expected = "01:00:00.000";
            string actual = Utilities.FormatMilliseconds(totalMilliseconds);

            Assert.AreEqual(expected, actual, "Minutes shall not exceed 59");
        }

        [TestMethod]
        public void HoursMoreThan99()
        {
            long totalMilliseconds = 360000000;

            string expected = "100:00:00.000";
            string actual = Utilities.FormatMilliseconds(totalMilliseconds);

            Assert.AreEqual(expected, actual, "Hours greater than 99 show all significant digits " + actual);

            totalMilliseconds = 3600000000;

            expected = "1000:00:00.000";
            actual = Utilities.FormatMilliseconds(totalMilliseconds);

            Assert.AreEqual(expected, actual, "Hours greater than 999 show all significant digits" + actual);
        }

    }
}