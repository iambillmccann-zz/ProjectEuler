using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// The prime 41, can be written as the sum of six consecutive primes:
    ///
    /// 41 = 2 + 3 + 5 + 7 + 11 + 13
    ///
    /// This is the longest sum of consecutive primes that adds to a prime below one-hundred.
    ///
    /// The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
    ///
    ///  Which prime, below one-million, can be written as the sum of the most consecutive primes?
    ///
    /// </summary>
    public class ConsecutivePrimeSum : IEulerSolution
    {
        private long max;

        public ConsecutivePrimeSum(long max)
        {
            this.max = max;
        }

        public string Compute()
        {
            List<long> primeNumbers = MathLibrary.GetPrime(max);
            long[] primeArray = primeNumbers.ToArray();

            long result = 0;
            int maxSequence = 0;

            for (long index = 0; index < primeArray.Length; index++)
            {
                if (result + primeArray[index] > max) break;
                long candidate = primeArray[index];
                int sequenceSize = 1;

                for (long index2 = index + 1; index2 < primeArray.Length; index2++)
                {
                    if (candidate + primeArray[index2] > max) break;
                    candidate += primeArray[index2];
                    sequenceSize++;
                    if (primeNumbers.Contains(candidate))
                        if (sequenceSize > maxSequence)
                        {
                            maxSequence = sequenceSize;
                            result = candidate;
                        }
                }
            }

            return result.ToString();
        }
    }
}
