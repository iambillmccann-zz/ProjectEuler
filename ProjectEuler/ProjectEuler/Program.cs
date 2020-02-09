using EulerLibrary.Problems;
using EulerLibrary;
using System.Diagnostics;

namespace ProjectEuler.Problems
{
    class Program
    {
        private static Stopwatch totalTime;

        static void Main()
        {
            int firstProblem = 51;                                 // change this to the first problem to solve
            int lastProblem = firstProblem;                        // change this to the last problem to solve

            ProblemFactory problemFactory = new ProblemFactory();
            totalTime = new Stopwatch();
            
            for (int problemNumber = firstProblem; problemNumber <= lastProblem; problemNumber++)
            {
                totalTime.Reset();
                totalTime.Start();
                string result = problemFactory.GetSolution(problemNumber).Compute();
                totalTime.Stop();

                System.Console.WriteLine("\n-----------------------------------------------------------------------");
                System.Console.WriteLine("Solution to problem " + problemNumber + " = " + result);
                System.Console.WriteLine("Execution time was " + Utilities.FormatMilliseconds(totalTime.ElapsedMilliseconds));
                System.Console.WriteLine("-----------------------------------------------------------------------");
            }
            System.Console.WriteLine("Press any key to continue");
            System.Console.ReadKey();
        }
    }
}
