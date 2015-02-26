using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. 
    /// For example, 2143 is a 4-digit pandigital and is also prime.
    ///
    /// What is the largest n-digit pandigital prime that exists?
    ///
    /// </summary>
    public class PandigitalPrime : IEulerSolution
    {
        public string Compute()
        {
            long result = 0;
            string digits = null;

            for (int digit = 1; digit <= 9; digit++)
            {
                digits += digit.ToString();
                Premutations premutations = new Premutations(digits);
                for (int index = 1; index <= premutations.Count(); index++)
                {
                    string premutation = premutations.GetPremutation(index);
                    long candidate = long.Parse(premutation);
                    if (candidate > result)
                        if (MathLibrary.IsPrime(candidate)) result = candidate;
                }
            }

            return result.ToString();
        }
    }
}
