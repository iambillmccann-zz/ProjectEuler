using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// If perimeter is the perimeter of a right angle triangle with integral length sides, {a,b,c}, 
    /// there are exactly three solutions for perimeter = 120.
    ///
    /// {20,48,52}, {24,45,51}, {30,40,50}
    ///
    /// For which value of perimeter ≤ 1000, is the number of solutions maximised?
    ///
    /// </summary>
    public class IntegerRightTriangles : IEulerSolution
    {
        long result = 0;
        long maxSolutions = 0;
        public string Compute()
        {
            for (long perimeter = 3; perimeter <= 1000; perimeter++)        // spin through possible perimeters
            {
                int solutions = 0;
                for (long sideC = 1; sideC < perimeter - 2; sideC++)
                    for (long sideA = 1; sideA < perimeter - (sideC / 2); sideA++)
                    {
                        long sideB = perimeter - sideC - sideA;
                        if ((sideC * sideC) == (sideA * sideA) + (sideB * sideB)) solutions++;
                    }
                if (solutions > maxSolutions)
                {
                    maxSolutions = solutions;
                    result = perimeter;
                }
            }
            return result.ToString();
        }
    }
}
