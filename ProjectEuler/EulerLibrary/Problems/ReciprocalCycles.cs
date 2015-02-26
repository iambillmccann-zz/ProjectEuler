using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class ReciprocalCycles : IEulerSolution
    {
        /// <summary>
        /// A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:
        ///
        /// 1/2 =  0.5 
        /// 1/3 =  0.(3) 
        /// 1/4 =  0.25 
        /// 1/5 =  0.2 
        /// 1/6 =  0.1(6) 
        /// 1/7 =  0.(142857) 
        /// 1/8 =  0.125 
        /// 1/9 =  0.(1) 
        /// 1/10 =  0.1 
        /// 
        /// Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.
        /// 
        /// Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
        /// </summary>
        /// <returns></returns>
        public long maxLength { get; set; }
        private long trip;
        private long denominator;
        private List<long> numerators;
        private long reciprocalLength;
        bool doneCounting;
        private long repeatedNumerator;

        public ReciprocalCycles(long inMaxlength)
        {
            maxLength = inMaxlength;
            denominator = 1;
        }

        public long GetReciprocalCycles(long inDenominator)
        {
            denominator = inDenominator;
            doneCounting = true;
            trip = 0;
            reciprocalLength = 0;
            repeatedNumerator = 0;
            numerators = new List<long>();
            countDecimals(1);
            return reciprocalLength;
        }

        public void countDecimals(long numerator)
        {
            trip++;
            if (trip > maxLength) return;                     // we've reached the max without a result

            long answer = numerator / denominator;
            long remainder = numerator % denominator;
            if (remainder == 0) return;                       // this one has a finite result

            long nextNumerator = (numerator - (denominator * answer)) * 10;
            if (numerators.Contains(nextNumerator))
            {
                doneCounting = false;
                repeatedNumerator = nextNumerator;
                return;                                       // discovered a repeating pattern
            }
            numerators.Add(nextNumerator);

            countDecimals(nextNumerator);                     // dig deeper
            if (!doneCounting) reciprocalLength++;
            if (repeatedNumerator == nextNumerator) doneCounting = true;

            return;                                           // start going back
        }
        public string Compute()
        {
            long result = 0;
            long maxCycle = 0;
            for (long denominator = 2; denominator < 1000; denominator++)
            {
                long cycle = GetReciprocalCycles(denominator);
                if (cycle > maxCycle)
                {
                    maxCycle = cycle;
                    result = denominator;
                }
            }

            return result.ToString();
        }
    }
}
