using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class LatticePaths : IEulerSolution
    {
        /// <summary>
        /// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
        /// How many such routes are there through a 20×20 grid?
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            int size = 20;
            long[,] lattice = new long[size + 1, size + 1];

            for (int hPosition = 0; hPosition <= size; hPosition++)
                for (int vPosition = 0; vPosition <= size; vPosition++)
                {
                    if ((hPosition * vPosition) == 0)        // if either position is 0
                        lattice[hPosition, vPosition] = 1;
                    else
                        lattice[hPosition, vPosition] = lattice[hPosition, vPosition - 1] + lattice[hPosition - 1, vPosition];
                }

            return lattice[size, size].ToString();
        }
    }
}
