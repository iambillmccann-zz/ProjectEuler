using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class LexigraphicPremutations : IEulerSolution
    {
        /// <summary>
        /// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
        /// If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. 
        /// The lexicographic permutations of 0, 1 and 2 are:
        /// 012   021   102   120   201   210
        /// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
        /// </summary>
        /// <returns>Zero</returns>
        public string Compute()
        {
            string result = null;
            string startingSequence = "0123456789";
            long max = 10;
            long numberToFind = 1000000;

            for (long digit = 0; digit < max - 1; digit++)
            {
                long factorial = MathLibrary.Factorial(max - digit - 1);
                long position = numberToFind / factorial;
                long remainder = numberToFind % factorial;

                if (remainder > 0) position++;

                result = result + startingSequence.Substring((int)position - 1, 1);
                startingSequence = startingSequence.Remove((int)position - 1, 1);

                long factorialBorder = (position - 1) * factorial;
                numberToFind = numberToFind - factorialBorder;
            }

            return result + startingSequence;
        }
    }
}
