using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// Take the number 192 and multiply it by each of 1, 2, and 3:
    ///
    /// 192 × 1 = 192
    /// 192 × 2 = 384
    /// 192 × 3 = 576
    ///
    /// By concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 192384576 
    /// the concatenated product of 192 and (1,2,3)
    ///
    /// The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, giving the pandigital, 
    /// 918273645, which is the concatenated product of 9 and (1,2,3,4,5).
    ///
    /// What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an 
    /// integer with (1,2, ... , n) where n > 1?
    ///
    /// </summary>
    public class PandigitalMultiples : IEulerSolution
    {
        /// <summary>
        /// Convert a list of digits to a long that is the concatenation of the elements.
        /// And yes, I know there is a more effecient way to do this without converting
        /// strings.
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        private long ToLong(List<long> digits)
        {
            string result = null;
            foreach (long digit in digits) result = digit.ToString() + result;
            return long.Parse(result);
        }

        /// <summary>
        /// Check to see if a list of digits is a pandigit multiple
        /// </summary>
        /// <param name="number"></param>
        /// <param name="n"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        private long isPandigital(long number, long n, List<long> digits)
        {
            List<long> allDigits = Utilities.CombineLists(MathLibrary.GetDigits(number * n), digits);
            if (Utilities.HasDuplicate(allDigits) | Utilities.HasZeros(allDigits)) return 0;
            if (allDigits.Count > 9) return 0;
            if (allDigits.Count == 9) return ToLong(allDigits);
            return isPandigital(number, ++n, allDigits);
        }

        public string Compute()
        {
            long result = 0;
            for (long startingNumber = 2; startingNumber < 10000; startingNumber++)
            {
                List<long> digits = new List<long>();
                long pandigitalMultiple = isPandigital(startingNumber, 1, digits);
                if (pandigitalMultiple > result) result = pandigitalMultiple;
            }
            return result.ToString();
        }
    }
}
