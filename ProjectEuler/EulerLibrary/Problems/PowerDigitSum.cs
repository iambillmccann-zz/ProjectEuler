using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class PowerDigitSum : IEulerSolution
    {
        /// <summary>
        /// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
        /// What is the sum of the digits of the number 2^1000?
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            int maxPower = 1000;
            ReallyBigInt result = new ReallyBigInt("2");
            for (int power = 2; power <= maxPower; power++) result = result.Addition(result);
            long sum = MathLibrary.SumDigits(result);
            return sum.ToString();
        }
    }
}
