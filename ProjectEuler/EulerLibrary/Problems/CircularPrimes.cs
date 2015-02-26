using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
    ///
    /// There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
    ///
    /// How many circular primes are there below one million?
    /// </summary>
    public class CircularPrimes : IEulerSolution
    {
        public string Compute()
        {
            List<long> primes = MathLibrary.GetPrime(1000000);                        // retrieve the list of prime numbers
            List<long> circularPrimes = new List<long>();
            char[] anyOf = { '0', '2', '4', '5', '6', '8' };
            bool isPrime;

            foreach (long primeNumber in primes)                                     // check each prime number
            {
                string stringDigits = primeNumber.ToString();
                isPrime = true;

                if (stringDigits.IndexOfAny(anyOf) >= 0 & stringDigits.Length > 1)   // rule out a number with even digits or a 5
                {
                    isPrime = false;
                    continue;
                }

                for (int index = 0; index < stringDigits.Length; index++)            // run through each circular premutation
                {
                    string circularDigits = stringDigits.Substring(index) + stringDigits.Substring(0, index);
                    if (!primes.Contains(long.Parse(circularDigits)))                  // if a number is not prime then stop checking
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime) circularPrimes.Add(primeNumber);
            }
            return circularPrimes.Count.ToString();
        }
    }
}
