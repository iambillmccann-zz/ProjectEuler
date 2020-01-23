using EulerLibrary.Problems;
using EulerLibrary;
using System;
using System.Diagnostics;

namespace ProjectEuler.Problems
{
    class Program
    {
        private static Stopwatch totalTime;
        private static string quitString = "Q";

        private static string getUserInput()
        {
            Console.Write("What problem shall I run? Or type 'Q' to quit. ");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            int problemNumber = 0;
            string userInput = null;

            ProblemFactory problemFactory = new ProblemFactory();
            totalTime = new Stopwatch();

            userInput = getUserInput();
            
            while (userInput.ToUpper() != quitString)
            {
                try
                {
                    problemNumber = Convert.ToInt32(userInput);
                    //ToDo check the problem number to verify that it has been implemented.

                    totalTime.Reset();
                    totalTime.Start();
                    string result = problemFactory.GetSolution(problemNumber).Compute();
                    totalTime.Stop();

                    Console.WriteLine("\n-----------------------------------------------------------------------");
                    Console.WriteLine("Solution to problem " + problemNumber + " = " + result);
                    Console.WriteLine("Execution time was " + Utilities.FormatMilliseconds(totalTime.ElapsedMilliseconds));
                    Console.WriteLine("-----------------------------------------------------------------------");
                    Console.WriteLine();

                }
                catch (FormatException)
                {
                    Console.WriteLine("\nSorry but I did not understand that. Please type the problem number or Q to quit.");
                }

                userInput = getUserInput();
            }

            Console.WriteLine("Goodbye. Press any key to continue");
            Console.ReadKey();
        }
    }
}
