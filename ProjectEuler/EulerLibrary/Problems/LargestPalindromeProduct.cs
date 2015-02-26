using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    class LargestPalindromeProduct : IEulerSolution
    {
        /// <summary>
        /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
        /// Find the largest palindrome made from the product of two 3-digit numbers
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            long result = 0;

            for (long number1 = 100; number1 < 1000; number1++)
            {
                for (long number2 = 100; number2 < 1000; number2++)
                {
                    long product = number1 * number2;
                    if (MathLibrary.ReverseDigits(product).Equals(product) & (product > result))
                        result = product;
                }
            }
            return result.ToString();
        }
    }
}
