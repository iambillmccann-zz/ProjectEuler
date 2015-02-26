using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, 
    /// is unusual in two ways: (i) each of the three terms are prime, and, (ii) each of the 
    /// 4-digit numbers are permutations of one another.
    ///
    /// There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting 
    /// this property, but there is one other 4-digit increasing sequence.
    ///
    /// What 12-digit number do you form by concatenating the three terms in this sequence?
    ///
    /// </summary>
    public class PrimePermutations : IEulerSolution
    {
        public string Compute()
        {
            List<long> primeNumbers = MathLibrary.GetPrime(9999);

            for (long candidate = 1000; candidate <= 9999; candidate++)
            {
                if (candidate.Equals(1487) | candidate.Equals(4817) | candidate.Equals(8147)) continue;   // ignore the sample case
                if (!primeNumbers.Contains(candidate)) continue;                                          // ignore when the first number is not prime
                string startSequence = candidate.ToString();
                Premutations premutations = new Premutations(startSequence);
                for (long index1 = 2; index1 < premutations.Count(); index1++)
                    for (long index2 = index1 + 1; index2 <= premutations.Count(); index2++)
                    {
                        string secondString = premutations.GetPremutation(index1);
                        long secondNumber = long.Parse(secondString);
                        if (candidate == secondNumber) continue;                                          // ignore if the first and second are the same
                        if (!primeNumbers.Contains(secondNumber)) continue;                               // ignore if the second is not prime

                        string thirdString = premutations.GetPremutation(index2);
                        long thirdNumber = long.Parse(thirdString);
                        if (candidate == thirdNumber) continue;                                           // Ignore if the first and third are the same
                        if (!primeNumbers.Contains(thirdNumber)) continue;                                // Ignore if the third number is not prime

                        if (secondNumber != thirdNumber)
                            if (Math.Abs(secondNumber - candidate) == Math.Abs(thirdNumber - secondNumber)) return candidate + secondString + thirdString;
                    }
            }

            return null;
        }
    }
}
