using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary
{
    /// <summary>
    /// Get all premutations of items in a list
    /// </summary>
    public class Premutations
    {
        private long[] things;
        private long count;
        private string originalSequence;

        /// <summary>
        /// Create premutations based on a list of digits
        /// </summary>
        /// <param name="things"></param>
        public Premutations(List<long> things)
        {
            this.things = things.ToArray<long>();
            count = MathLibrary.Factorial(things.Count);
            originalSequence = null;
            foreach (long digit in things) originalSequence = digit.ToString() + originalSequence;
        }

        /// <summary>
        /// Create premutations based on an array of digits
        /// </summary>
        /// <param name="things"></param>
        public Premutations(long[] things)
        {
            this.things = things;
            count = MathLibrary.Factorial(things.Length);
            originalSequence = null;
            foreach (long digit in things) originalSequence = digit.ToString() + originalSequence;
        }

        /// <summary>
        /// Create premutations base on a string of digits
        /// </summary>
        /// <param name="things"></param>
        public Premutations(string things)
        {
            this.originalSequence = things;
            count = MathLibrary.Factorial(things.Length);
        }

        /// <summary>
        /// retreive a specific lexical premutation
        /// </summary>
        /// <param name="workingNumberToFind"></param>
        /// <returns></returns>
        public string GetPremutation(long numberToFind)
        {
            string result = null;
            string startingSequence = originalSequence;
            long workingNumberToFind = numberToFind;

            for (long digit = 0; digit < originalSequence.Length - 1; digit++)
            {
                long factorial = MathLibrary.Factorial(originalSequence.Length - digit - 1);
                long position = workingNumberToFind / factorial;
                long remainder = workingNumberToFind % factorial;

                if (remainder > 0) position++;

                result = result + startingSequence.Substring((int)position - 1, 1);
                startingSequence = startingSequence.Remove((int)position - 1, 1);

                long factorialBorder = (position - 1) * factorial;
                workingNumberToFind = workingNumberToFind - factorialBorder;
            }

            return result + startingSequence;
        }

        /// <summary>
        /// Return the number of premutations of things
        /// </summary>
        /// <returns></returns>
        public long Count()
        {
            return count;
        }


    }
}
