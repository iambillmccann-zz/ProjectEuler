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
        /// Determine the number of terms in an Arithmetic Progression
        /// </summary>
        /// <param name="rangeStart">First number in the range</param>
        /// <param name="rangeStop">Last number in the range</param>
        /// <param name="difference">Difference between terms</param>
        /// <returns>The number of terms</returns>
        private long NumberOfTerms (long rangeStart, long rangeStop, long difference)
        {
            return (rangeStop - rangeStart) / difference;
        }

        /// <summary>
        /// Determine the last number in an Arithmetic Progression
        /// </summary>
        /// <param name="numberOfTerms">The number of terms</param>
        /// <param name="firstTerm">The first number</param>
        /// <param name="difference">The difference between terms</param>
        /// <returns>The largest value of the sequence</returns>
        private long LastTerm (long numberOfTerms, long firstTerm, long difference)
        {
            return firstTerm + difference * (numberOfTerms - 1);
        }

        /// <summary>
        /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        /// Find the sum of all the multiples of 3 or 5 below 1000.
        /// </summary>
        /// <returns>return the answer to the problem</returns>
        public string Compute()
        {
            long numberOfTerms = NumberOfTerms(1, 1000, 3);
            long lastTerm = LastTerm(numberOfTerms, 3, 3);
            long sum3 = MathLibrary.ArithmeticSeries(numberOfTerms, 3, lastTerm);

            numberOfTerms = NumberOfTerms(1, 1000, 5);
            lastTerm = LastTerm(numberOfTerms, 5, 5);
            long sum5 = MathLibrary.ArithmeticSeries(numberOfTerms, 5, lastTerm);

            numberOfTerms = NumberOfTerms(1, 1000, 15);
            lastTerm = LastTerm(numberOfTerms, 15, 15);
            long sum15 = MathLibrary.ArithmeticSeries(numberOfTerms, 15, lastTerm);

            return (sum3 + sum5 - sum15).ToString();

        }
    }
}
