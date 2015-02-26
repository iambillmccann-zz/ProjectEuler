using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class QuadraticPrimes : IEulerSolution
    {
        /// <summary>
        /// Euler discovered the remarkable quadratic formula:
        ///
        /// n² + n + 41
        ///
        /// It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. 
        /// However, when n = 40, 402 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly 
        /// when n = 41, 41² + 41 + 41 is clearly divisible by 41.
        /// 
        /// The incredible formula  n² − 79n + 1601 was discovered, which produces 80 primes for the 
        /// consecutive values n = 0 to 79. The product of the coefficients, −79 and 1601, is −126479.
        ///
        /// Considering quadratics of the form:
        ///
        /// n² + an + b, where |a| < 1000 and |b| < 1000
        ///
        /// where |n| is the modulus/absolute value of n
        /// e.g. |11| = 11 and |−4| = 4
        ///
        /// Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.
        /// </summary>
        /// <returns>Zero</returns>
        public string Compute()
        {
            long result = 0;
            List<long> primeNumbers = MathLibrary.GetPrime(15000);
            long maxSeries = 0;

            for (long a = -999; a < 999; a++)
                for (long b = -999; b < 999; b++)
                {
                    long n = 0;
                    long number = 0;
                    while (true)
                    {
                        number = MathLibrary.GeneralQuadraticFormula(n, a, b);
                        if (!primeNumbers.Contains(number))
                        {
                            if (number > 15000) System.Console.WriteLine("We need prime number up to " + number.ToString());
                            if (n > 0 & n > maxSeries)
                            {
                                result = a * b;
                                maxSeries = n;
                            }
                            break;
                        }
                        n++;
                    }
                }

            return result.ToString();
        }
    }
}
