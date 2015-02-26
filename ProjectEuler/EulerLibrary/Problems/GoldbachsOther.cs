using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// It was proposed by Christian Goldbach that every odd composite number can be 
    /// written as the sum of a prime and twice a square.
    ///
    /// 9 = 7 + 2×12
    /// 15 = 7 + 2×22
    /// 21 = 3 + 2×32
    /// 25 = 7 + 2×32
    /// 27 = 19 + 2×22
    /// 33 = 31 + 2×12
    ///
    /// It turns out that the conjecture was false.
    ///
    /// What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?
    ///
    /// </summary>
    /// <returns></returns>
    public class GoldbachsOther : IEulerSolution
    {
        private List<long> GetDoubleSquares(long max)
        {
            List<long> doubleSquares = new List<long>();
            for (long index = 1; index <= max; index++)
                doubleSquares.Add(index*index*2);
            return doubleSquares;
        }

        public string Compute()
        {
            long result = 0;
            long max = 10000;
            List<long> primeNumbers = MathLibrary.GetPrime(max);
            List<long> doubleSquares = GetDoubleSquares(max);

            for (long number = 15; number <= max; number += 2)
            {
                if (primeNumbers.Contains(number)) continue;
                bool notConjecture = true;
                foreach (long primeNumber in primeNumbers)
                {
                    if (primeNumber > number) break;
                    if (doubleSquares.Contains(number - primeNumber))
                    {
                        notConjecture = false;
                        break;
                    }
                }
                if (notConjecture)
                {
                    result = number;
                    break;
                }
            }

            return result.ToString();
        }
    }
}
