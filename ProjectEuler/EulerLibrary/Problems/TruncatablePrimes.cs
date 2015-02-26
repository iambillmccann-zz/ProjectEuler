using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits 
    /// from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from 
    /// right to left: 3797, 379, 37, and 3.
    ///
    /// Find the sum of the only eleven primes that are both truncatable from left to right and right to left.
    ///
    /// NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
    ///
    /// </summary>
    public class TruncatablePrimes : IEulerSolution
    {
        public string Compute()
        {
            long result = 0;
            int count = 0;
            List<long> primes = MathLibrary.GetPrime(1000000);                        // retrieve the list of prime numbers

            foreach (long primeNumber in primes)
            {
                if (primeNumber <= 7) continue;                                       // by definition primes less than 7 are not truncatable
                bool isPrime = true;
                string primeString = primeNumber.ToString();

                for (int index = 0; index < primeString.Length; index++)
                {
                    string left2Right = primeString.Substring(index);
                    string right2Left = primeString.Substring(0, primeString.Length - index);
                    if (!primes.Contains(long.Parse(left2Right)) | !primes.Contains(long.Parse(right2Left)))
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    count++;
                    result += primeNumber;
                    if (count.Equals(11)) break;                                       // by definition there are only 11
                }
            }

            return result.ToString();
        }
    }
}
