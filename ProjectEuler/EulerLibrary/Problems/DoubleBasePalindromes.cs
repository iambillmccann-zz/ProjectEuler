using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.
    ///
    /// Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
    ///
    /// (Please note that the palindromic number, in either base, may not include leading zeros.)
    ///
    /// </summary>
    public class DoubleBasePalindromes : IEulerSolution
    {
        public string Reverse(string theString)
        {
            string result = null;
            for (int index = 0; index < theString.Length; index++) result = theString.Substring(index, 1) + result;
            return result;
        }

        public string Compute()
        {
            long result = 0;
            for (long number = 1; number < 1000000; number++)
            {
                if (MathLibrary.ReverseDigits(number).Equals(number))
                {
                    string binary = Convert.ToString(number, 2);
                    string reverseBinary = Reverse(binary);
                    if (reverseBinary.Equals(binary)) result += number;
                }
            }

            return result.ToString();
        }
    }
}
