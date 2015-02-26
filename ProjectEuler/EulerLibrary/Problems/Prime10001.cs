using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class Prime10001 : IEulerSolution
    {
        /// <summary>
        /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
        /// What is the 10 001st prime number?
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            long result = 0;
            int position = 10001;
            List<long> primeNumbers = MathLibrary.GetPrime(110000);
            List<long> answers = primeNumbers.GetRange(position - 1, 1);
            foreach (long answer in answers)
                result = answer;
            return result.ToString();
        }
    }
}
