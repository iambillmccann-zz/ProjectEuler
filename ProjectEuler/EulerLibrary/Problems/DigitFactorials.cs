using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
    ///
    /// Find the sum of all numbers which are equal to the sum of the factorial of their digits.
    ///
    /// Note: as 1! = 1 and 2! = 2 are not sums they are not included.
    /// </summary>
    public class DigitFactorials : IEulerSolution
    {
        public string Compute()
        {
            long[] digitFactorials = new long[10];
            long result = 0;

            for (int digit = 0; digit < 10; digit++)
                digitFactorials[digit] = MathLibrary.Factorial(digit);

            for (int number = 3; number < 50000; number++)
            {
                List<long> digits = MathLibrary.GetDigits(number);
                long factorialSum = 0;
                foreach (long digit in digits) factorialSum += digitFactorials[digit];
                if (factorialSum == number) result += number;
            }

            return result.ToString();
        }
    }
}
