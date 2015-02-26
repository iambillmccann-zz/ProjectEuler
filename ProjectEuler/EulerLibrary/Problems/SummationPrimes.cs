using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class SummationPrimes : IEulerSolution
    {
        /// <summary>
        /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
        /// Find the sum of all the primes below two million.
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            List<long> primeNumbers = MathLibrary.GetPrime(2000000);
            return MathLibrary.SeriesSum(primeNumbers).ToString();
        }
    }
}
