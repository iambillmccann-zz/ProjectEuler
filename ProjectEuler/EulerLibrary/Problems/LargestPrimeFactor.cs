using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class LargestPrimeFactor : IEulerSolution
    {
        /// <summary>
        /// The prime factors of 13195 are 5, 7, 13 and 29.
        /// What is the largest prime factor of the number 600,851,475,143?
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            long result = 0;
            long value = 600851475143;
            List<long> factors = MathLibrary.GetFactors(value);
            List<long> answers = factors.GetRange(factors.Count - 1, 1);
            foreach (long answer in answers)
                result = answer;
            return result.ToString();
        }
    }
}
