using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// The first two consecutive numbers to have two distinct prime factors are:
    ///
    /// 14 = 2 × 7
    /// 15 = 3 × 5
    ///
    /// The first three consecutive numbers to have three distinct prime factors are:
    ///
    /// 644 = 2² × 7 × 23
    /// 645 = 3 × 5 × 43
    /// 646 = 2 × 17 × 19.
    ///
    /// Find the first four consecutive integers to have four distinct prime factors. What is the first of these numbers?
    ///
    /// </summary>
    public class DistinctPrimesFactors : IEulerSolution
    {
        private long consecutive;

        public DistinctPrimesFactors(long consecutive)
        {
            this.consecutive = consecutive;
        }

        public string Compute()
        {
            long result = 0;
            long limit = 1000000;
            List<long> primeNumbers = MathLibrary.GetPrime(10000);

            long count = 10;      // 10 is an arbitrary starting point. The starting point must be greater than 1

            while (true)
            {
                if (count++ > limit) break;
                for (long index = 0; index < consecutive; index++)
                {
                    long factors = MathLibrary.GetDistinctFactors(count + index, primeNumbers).Count;
                    if (!factors.Equals(consecutive)) break;
                    if (index.Equals(consecutive - 1)) return count.ToString();
                }
            }

            return result.ToString();
        }
    }
}
