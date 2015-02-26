using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.
    ///
    /// Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.
    ///
    /// </summary>
    public class SelfPowers : IEulerSolution
    {
        private long max;

        public SelfPowers(long max)
        {
            this.max = max;
        }

        public string Compute()
        {
            ReallyBigInt result = new ReallyBigInt("0");
            ReallyBigInt number = new ReallyBigInt("0");

            for (long index = 1; index <= max; index++)
            {
                System.Console.Write((index - 1).ToString() + " ");
                if (MathLibrary.IsMultiple(index, 10)) continue;

                number = new ReallyBigInt(index.ToString());
                number = number.Power(index);

                result = result.Addition(number);
            }
            return result.value;
        }
    }
}
