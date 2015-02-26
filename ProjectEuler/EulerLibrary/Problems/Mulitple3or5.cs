using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class Mulitple3or5 : IEulerSolution
    {
        /// <summary>
        /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        /// Find the sum of all the multiples of 3 or 5 below 1000.
        /// </summary>
        /// <returns>return the answer to the problem</returns>
        public string Compute()
        {
            long result = 0;
            for (long number = 1; number < 1000; number++)
                if (MathLibrary.IsMultiple(number, 3))
                    result += number;
                else
                    if (MathLibrary.IsMultiple(number, 5)) result += number;
            return result.ToString();
        }
    }
}
