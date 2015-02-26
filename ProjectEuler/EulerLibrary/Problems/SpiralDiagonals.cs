using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class SpiralDiagonals : IEulerSolution
    {
        /// <summary>
        /// Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
        ///
        /// 21 22 23 24 25
        /// 20  7  8  9 10
        /// 19  6  1  2 11
        /// 18  5  4  3 12
        /// 17 16 15 14 13
        ///
        /// It can be verified that the sum of the numbers on the diagonals is 101.
        ///
        /// What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
        /// </summary>
        /// <returns>Zero</returns>
        public string Compute()
        {
            long result = 1;
            long lastItem = 1;
            long matrixSize = 1001;


            for (int index = 1; index <= matrixSize / 2; index++)
            {
                long firstCorner = lastItem + (index * 2);
                long secondCorner = firstCorner + (index * 2);
                long thirdCorner = secondCorner + (index * 2);
                lastItem = thirdCorner + (index * 2);
                result += (firstCorner + secondCorner + thirdCorner + lastItem);
            }

            return result.ToString();
        }
    }
}
