using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class GenericSolution : IEulerSolution
    {
        /// <summary>
        /// The generic solution class. The factory will use this as the default solution.
        /// </summary>
        /// <returns>A message indicating that no solution exists.</returns>
        public string Compute()
        {
            return "The requested problem has not been solved";
        }
    }
}
