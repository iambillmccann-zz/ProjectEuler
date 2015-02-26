using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class ProblemFactory
    {
        /// <summary>
        /// The ProblemFactory class using the factory pattern to return the solution to a 
        /// given problem number.
        /// </summary>
        /// <param name="problemNumber">The number of the problem.</param>
        /// <returns>The class that will solve the problem</returns>
        public IEulerSolution GetSolution(int problemNumber)
        {
            switch (problemNumber)
            {
                case 1: return new Mulitple3or5();
                case 2: return new EvenFibonacci();
                case 3: return new LargestPrimeFactor();
                case 4: return new LargestPalindromeProduct();
                case 5: return new SmallestMultiple();
                case 6: return new SumSquareDifference();
                case 7: return new Prime10001();
                case 8: return new LargestProductSeries();
                case 9: return new PythagoreanTriplet();
                case 10: return new SummationPrimes();
                case 11: return new LargestProductGrid();
                case 12: return new HighlyDivisibleTriangle();
                case 13: return new LargeSum();
                case 14: return new LongestCollatz();
                case 15: return new LatticePaths();
                case 16: return new PowerDigitSum();
                case 17: return new NumberLetterCounts();
                case 18: return new MaximumPathSum();
                case 19: return new CountingSundays();
                case 20: return new FactorialDigitSum();
                case 21: return new AmicableNumbers();
                case 22: return new NamesScores();
                case 23: return new NonabundantSums();
                case 24: return new LexigraphicPremutations();
                case 25: return new Fibonacci1000digit();
                case 26: return new ReciprocalCycles(10000);
                case 27: return new QuadraticPrimes();
                case 28: return new SpiralDiagonals();
                case 29: return new DistinctPowers(100);
                case 30: return new DigitFifthPowers();
                case 31: return new CoinSums(200);
                case 32: return new PandigitalProducts();
                case 33: return new DigitCancellingFractions();
                case 34: return new DigitFactorials();
                case 35: return new CircularPrimes();
                case 36: return new DoubleBasePalindromes();
                case 37: return new TruncatablePrimes();
                case 38: return new PandigitalMultiples();
                case 39: return new IntegerRightTriangles();
                case 40: return new ChampernownesConstant();
                case 41: return new PandigitalPrime();
                case 42: return new CodedTriangleNumbers();
                case 43: return new SubstringDivisibility();
                case 44: return new PentagonNumbers();
                case 45: return new TriPentHex();
                case 46: return new GoldbachsOther();
                case 47: return new DistinctPrimesFactors(4);
                case 48: return new SelfPowers(1000);
                case 49: return new PrimePermutations();
                case 50: return new ConsecutivePrimeSum(1000000);
                case 51: return new PrimeDigitReplacements();
                default: return new GenericSolution();
            }
        }
    }
}
