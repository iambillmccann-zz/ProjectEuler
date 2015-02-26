using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify 
    /// it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.
    ///
    /// We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
    ///
    /// There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing 
    /// two digits in the numerator and denominator.
    ///
    /// If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
    ///
    /// </summary>
    public class DigitCancellingFractions : IEulerSolution
    {
        public string Compute()
        {
            long numeratorProduct = 1;
            long denominatorProduct = 1;

            for (long numerator = 10; numerator < 100; numerator++)
                for (long denominator = numerator + 1; denominator < 100; denominator++)
                {
                    long numeratorTens = numerator / 10;
                    long numeratorOnes = numerator % 10;
                    long denominatorTens = denominator / 10;
                    long denominatorOnes = denominator % 10;
                    if (numeratorOnes == 0 & denominatorOnes == 0) continue;
                    if (numerator == denominator) continue;
                    if (numeratorTens == denominatorTens) if (denominatorOnes != 0) if ((float)numeratorOnes / (float)denominatorOnes == (float)numerator / (float)denominator) { numeratorProduct *= numerator; denominatorProduct *= denominator; }
                    if (numeratorTens == denominatorOnes) if (denominatorTens != 0) if ((float)numeratorOnes / (float)denominatorTens == (float)numerator / (float)denominator) { numeratorProduct *= numerator; denominatorProduct *= denominator; }
                    if (numeratorOnes == denominatorTens) if (denominatorOnes != 0) if ((float)numeratorTens / (float)denominatorOnes == (float)numerator / (float)denominator) { numeratorProduct *= numerator; denominatorProduct *= denominator; }
                    if (numeratorOnes == denominatorOnes) if (denominatorTens != 0) if ((float)numeratorTens / (float)denominatorTens == (float)numerator / (float)denominator) { numeratorProduct *= numerator; denominatorProduct *= denominator; }
                }
            return (denominatorProduct / numeratorProduct ).ToString(); // This isn't a true simplification, but it works in this situation
        }
    }
}
