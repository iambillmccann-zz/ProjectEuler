using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class LongestCollatz : IEulerSolution
    {
        /// <summary>
        /// The following iterative sequence is defined for the set of positive integer:
        /// n → n/2 (n is even)
        /// n → 3n + 1 (n is odd)
        /// Using the rule above and starting with 13, we generate the following sequence:
        /// 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
        /// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
        /// Which starting number, under one million, produces the longest chain?
        /// NOTE: Once the chain starts the terms are allowed to go above one million.
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            int result = 0;
            int lastNumber = 999999;
            long longestSequence = 0;
            MathLibrary.SetupTrials(lastNumber + 1);
            MathLibrary.SetTrialValue(1, 1);
            for (int index = 1; index <= lastNumber; index++)
            {
                long length = MathLibrary.CollatzLength(index);
                //              System.Console.WriteLine("Number = " + index.ToString() + " and Length = " + length);
                if (length > longestSequence)
                {
                    longestSequence = length;
                    result = index;
                }
            }
            return result.ToString();
        }
    }
}
