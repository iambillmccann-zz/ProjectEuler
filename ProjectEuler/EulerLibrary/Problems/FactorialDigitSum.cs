using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class FactorialDigitSum : IEulerSolution
    {
        /// <summary>
        /// n! means n × (n − 1) × ... × 3 × 2 × 1
        /// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
        /// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
        /// Find the sum of the digits in the number 100!
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            return MathLibrary.SumDigits(MathLibrary.BigFactorial(100)).ToString();
        }
    }
}
