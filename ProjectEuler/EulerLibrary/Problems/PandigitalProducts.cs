using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerLibrary;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; 
    /// for example, the 5-digit number, 15234, is 1 through 5 pandigital.
    ///
    /// The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, 
    /// and product is 1 through 9 pandigital.
    ///
    /// Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
    ///
    /// HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
    /// </summary>
    public class PandigitalProducts : IEulerSolution
    {
        public string Compute()
        {
            List<long> digits;
            List<long> divisors;
            List<long> multiplicandDigits;
            List<long> multiplierDigits;
            List<long> result = new List<long>();

            for (long product = 1000; product < 10000; product++)
            {
                digits = MathLibrary.GetDigits(product);
                if (Utilities.HasDuplicate(digits) | Utilities.HasZeros(digits)) continue;
                divisors = MathLibrary.GetDivisors(product);
                int currentElement = 1;
                while (currentElement < divisors.Count - 1)
                {
                    multiplicandDigits = MathLibrary.GetDigits(divisors.ElementAt(currentElement++));
                    multiplierDigits = MathLibrary.GetDigits(divisors.ElementAt(currentElement++));
                    List<long> allDigits = Utilities.CombineLists(Utilities.CombineLists(multiplicandDigits, multiplierDigits), digits);
                    if (allDigits.Count != 9) continue;
                    if (Utilities.HasDuplicate(allDigits) | Utilities.HasZeros(allDigits)) continue;
                    if (!result.Contains(product)) result.Add(product);
                    break;
                }
            }
            return MathLibrary.SeriesSum(result).ToString();
        }
    }
}
