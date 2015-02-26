using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class AmicableNumbers : IEulerSolution
    {
        /// <summary>
        /// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
        /// If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
        /// For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
        /// Evaluate the sum of all the amicable numbers under 10000.
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            long result = 0;
            List<long> amicableNumbers = new List<long>();
            long[] divisorSums = new long[10000];

            for (long number = 1; number < 10000; number++)
                divisorSums[number] = MathLibrary.SeriesSum(MathLibrary.GetDivisors(number));

            for (long number = 2; number < 10000; number++)
            {
                long sum = divisorSums[number];

                if (sum < 10000)
                    if (sum != number)
                        if (divisorSums[sum].Equals(number)) result += number;
            }

            return result.ToString(); ;
        }
    }
}
