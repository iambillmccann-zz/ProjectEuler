using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class NonabundantSums : IEulerSolution
    {
        /// <summary>
        /// A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
        /// For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
        /// A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
        /// As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as 
        /// the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integer greater than 28123 
        /// can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis 
        /// even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.
        /// Find the sum of all the positive integer which cannot be written as the sum of two abundant numbers.
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            long result = 0;
            long maxSize = 28124;
            int[] numberTypes = new int[maxSize];

            for (long number = 1; number < maxSize; number++)
            {
                List<long> divisors = MathLibrary.GetDivisors(number);
                long sumDivisors = MathLibrary.SeriesSum(divisors);

                if (sumDivisors < number) numberTypes[number] = -1;
                else if (sumDivisors > number) numberTypes[number] = 1;
                else numberTypes[number] = 0;

                bool abundantSum = false;
                for (long firstNumber = 1; firstNumber <= number / 2; firstNumber++)
                    if (numberTypes[firstNumber] + numberTypes[number - firstNumber] >= 2)
                    {
                        abundantSum = true;
                        break;
                    }
                if (!abundantSum) result += number;
            }

            return result.ToString();
        }
    }
}
