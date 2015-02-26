using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class SmallestMultiple : IEulerSolution
    {
        /// <summary>
        /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            long result = 0;
            long max = 20;
            bool notDone = true;

            while (notDone)
            {
                result += max * (max - 1);
                long trial = max - 2;
                while (MathLibrary.IsMultiple(result, trial--))
                    if (trial.Equals(1))
                    {
                        notDone = false;
                        break;
                    }
            }

            return result.ToString();
        }
    }
}
