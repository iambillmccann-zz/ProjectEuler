using EulerLibrary.Problems;
using EulerLibrary;
using System;
using System.Diagnostics;

namespace ProjectEuler.Problems
{
    class Program
    {
        private static Stopwatch totalTime;
        private const string quitString = "Q";
        private const int lastProblem = 51;

        /// <summary>
        /// getUserInput is a simple method for reading from the console.
        /// </summary>
        /// <returns>A string that represents the user's input.</returns>
        private static int GetUserInput()
        {
            Console.Write("What problem shall I run? Or type 'Q' to quit. ");
            return CheckUserInput(Console.ReadLine());
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
        private static int CheckUserInput(string userInput)
        {
            int result = -1;
            if (userInput.ToUpper() == quitString) return result;

            if (!int.TryParse(userInput, out result))
            {
                Console.WriteLine("\nSorry but I did not understand that. Please type the problem number or Q to quit.");
                return GetUserInput();
            }

            if (result < 1)
            {
                Console.WriteLine("\nBTW, problem numbers are positive integers.");
                return GetUserInput();
            }  
            
            if (result > lastProblem)
            {
                Console.WriteLine("\nI have only completed problems 1 through " + lastProblem.ToString());
                return GetUserInput();
            }

            return result;
        }

        /// <summary>
        /// This is the main program.
        /// </summary>
        /// 
        static void Main()
        {
            int problemNumber;

            // ProblemFactory problemFactory = new ProblemFactory();
            totalTime = new Stopwatch();

            problemNumber = GetUserInput();

            while (problemNumber > 0)
            {
                totalTime.Reset();
                totalTime.Start();
                string result = ProblemFactory.GetSolution(problemNumber).Compute();
                totalTime.Stop();

                Console.WriteLine("\n-----------------------------------------------------------------------");
                Console.WriteLine("Solution to problem " + problemNumber + " = " + result);
                Console.WriteLine("Execution time was " + Utilities.FormatMilliseconds(totalTime.ElapsedMilliseconds));
                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine();
                problemNumber = GetUserInput();
            }

            Console.WriteLine("Goodbye. Press any key to continue");
            Console.ReadKey();
        }
    }
}
