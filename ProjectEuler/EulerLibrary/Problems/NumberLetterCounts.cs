using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class NumberLetterCounts : IEulerSolution
    {
        /// <summary>
        /// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
        /// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used? 
        /// NOTE: Do not index spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            int numberOfLetters = 0;
            for (int number = 1; number <= 1000; number++)
            {
                numberOfLetters += MathLibrary.NumberAsString(number).Length;
            }
            return numberOfLetters.ToString();
        }
    }
}
