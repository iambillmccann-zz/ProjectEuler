using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class PythagoreanTriplet : IEulerSolution
    {
        /// <summary>
        /// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
        /// a^2 + b^2 = c^2
        /// For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
        /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
        /// Find the product abc.
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            long result = 0;

            for (long a = 1; a <= 333; a++)
            {
                bool done = false;
                long b = a + 1;                // b must be greater than a
                while (!done)
                {
                    long c = 1000 - (a + b);   // a + b + c must equal 1000
                    if (MathLibrary.Square(a) + MathLibrary.Square(b) == MathLibrary.Square(c)) return (a * b * c).ToString();
                    if (++b >= c) done = true; // c must be greater than b
                }
            }
            return result.ToString();
        }
    }
}
