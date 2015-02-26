using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the 
    /// digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.
    ///
    /// Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:
    /// •d2d3d4=406 is divisible by 2
    /// •d3d4d5=063 is divisible by 3
    /// •d4d5d6=635 is divisible by 5
    /// •d5d6d7=357 is divisible by 7
    /// •d6d7d8=572 is divisible by 11
    /// •d7d8d9=728 is divisible by 13
    /// •d8d9d10=289 is divisible by 17
    ///
    /// Find the sum of all 0 to 9 pandigital numbers with this property.
    ///
    /// </summary>
    public class SubstringDivisibility : IEulerSolution
    {
        public string Compute()
        {
            long result = 0;
            Premutations premutations = new Premutations("0123456789");

            for (long index = 1; index <= premutations.Count(); index++)
            {
                string premutation = premutations.GetPremutation(index);
                if (long.Parse(premutation.Substring(1, 3)) % 2 > 0) continue;
                if (long.Parse(premutation.Substring(2, 3)) % 3 > 0) continue;
                if (long.Parse(premutation.Substring(3, 3)) % 5 > 0) continue;
                if (long.Parse(premutation.Substring(4, 3)) % 7 > 0) continue;
                if (long.Parse(premutation.Substring(5, 3)) % 11 > 0) continue;
                if (long.Parse(premutation.Substring(6, 3)) % 13 > 0) continue;
                if (long.Parse(premutation.Substring(7, 3)) % 17 > 0) continue;
                result += long.Parse(premutation);
            }

            return result.ToString();
        }
    }
}
