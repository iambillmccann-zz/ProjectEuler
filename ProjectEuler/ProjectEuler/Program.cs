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
        private static int lastProblem = 51;

        /// <summary>
        /// getUserInput is a simple method for reading from the console.
        /// </summary>
        /// <returns>A string that represents the user's input.</returns>
        private static int getUserInput()
        {
            Console.Write("What problem shall I run? Or type 'Q' to quit. ");
            return checkUserInput(Console.ReadLine());
        }

        /// <summary>
        /// checkUserInput will validate the user's input. This is a very redimentary
        /// validation method. It checks three things ...
        /// 1. Checks for the letter "Q"
        /// 2. Checks for an integer
        /// 3. Checks that the integer is positive
        /// 4. Checks that the integer is no greater than the last problem solved.
        /// These checks assume that problems are solved in order.
        /// Note: If the user enters "Q", a minus one is returned to the caller.
        /// </summary>
        /// <param name="userInput">A string entered by the user.</param>
        /// <returns>A valid integer result.</returns>
        private static int checkUserInput(string userInput)
        {
            int result = -1;
            if (userInput.ToUpper() == quitString) return result;

            try
            {
                result = Convert.ToInt32(userInput);
                if (result < 1)
                {
                    Console.WriteLine("\nBTW, problem numbers are positive integers.");
                    result = getUserInput();
                } else if (result > lastProblem)
                {
                    Console.WriteLine("\nI have only completed problems 1 through " + lastProblem.ToString());
                    result = getUserInput();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSorry but I did not understand that. Please type the problem number or Q to quit.");
                result = getUserInput();
            }

            return result;
        }

        static void Main(string[] args)
        {
            int problemNumber = 0;

            ProblemFactory problemFactory = new ProblemFactory();
            totalTime = new Stopwatch();

            problemNumber = getUserInput();

            while (problemNumber > 0)
            {
                totalTime.Reset();
                totalTime.Start();
                string result = problemFactory.GetSolution(problemNumber).Compute();
                totalTime.Stop();

                Console.WriteLine("\n-----------------------------------------------------------------------");
                Console.WriteLine("Solution to problem " + problemNumber + " = " + result);
                Console.WriteLine("Execution time was " + Utilities.FormatMilliseconds(totalTime.ElapsedMilliseconds));
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine();
                problemNumber = getUserInput();
            }

            Console.WriteLine("Goodbye. Press any key to continue");
            Console.ReadKey();
        }
    }
}
