using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
    ///
    ///  1634 = 1^4 + 6^4 + 3^4 + 4^4
    ///  8208 = 8^4 + 2^4 + 0^4 + 8^4
    ///  9474 = 9^4 + 4^4 + 7^4 + 4^4
    ///
    /// As 1 = 14 is not a sum it is not included.
    ///
    /// The sum of these numbers is 1634 + 8208 + 9474 = 19316.
    ///
    /// Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
    /// 
    /// The answer is not 248860
    /// </summary>
    public class DigitFifthPowers : IEulerSolution
    {
        public string Compute()
        {
            long result = 0;

            for (long number = 2; number <= 200000; number++)
            {
                List<long> digits = MathLibrary.GetDigits(number);
                long sumOfPowers = 0;
                foreach (long digit in digits) sumOfPowers += MathLibrary.Power(digit, 5);
                if (sumOfPowers.Equals(number)) result += number;
            }
            return result.ToString();
        }
    }
}
