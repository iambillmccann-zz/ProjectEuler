using System;
using System.Collections.Generic;
using System.Linq;

namespace EulerLibrary
{
    public static class MathLibrary
    {
        private static int[] trials;
        private static int sizeOfTrial;

        /// <summary>
        /// The Arithmetic Series is the sum of an Arithmetic Progression
        /// </summary>
        /// <param name="numberOfTerms">Number of terms in the series</param>
        /// <param name="firstTerm">The first term</param>
        /// <param name="lastTerm">The last term</param>
        /// <returns>The value of the Arithmetic Series</returns>
        public static long ArithmeticSeries(long numberOfTerms, long firstTerm, long lastTerm)
        {
            return numberOfTerms * (firstTerm + lastTerm) / 2;
        }

        /// <summary>
        /// This method determines if a number will divide evenly longo another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public static bool IsMultiple(long value, long divisor)
        {
            if (divisor == 0) return false;
            if (value % divisor == 0) return true;
            return false;
        }

        /// <summary>
        /// Check to see if a number is even
        /// </summary>
        /// <param name="number">The number to check</param>
        /// <returns>True when even and false when odd</returns>
        public static bool IsEven(long number)
        {
            return IsMultiple(number, 2);
        }

        /// <summary>
        /// This method returns a collection of prime numbers
        /// </summary>
        /// <param name="max">Stop checking at this number</param>
        /// <returns>Collection of integer that are prime</returns>
        public static List<long> GetPrime(long max)
        {
            List<long> primeNumbers = new List<long>();

            for (long number = 2; number <= max; number++)
            {
                bool isPrime = true;
                foreach (long divisor in primeNumbers)
                {
                    if (Math.Sqrt((double)number) < divisor) break;
                    if (IsMultiple(number, divisor)) isPrime = false;
                }
                if (isPrime.Equals(true)) primeNumbers.Add(number);
            }

            return primeNumbers;
        }

        /// <summary>
        /// Determine is a specific number is prime
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPrime(long number)
        {
            long maxDivisor = (long)Math.Sqrt((double)number);

            if (IsMultiple(number, 2)) return false;
            if (IsMultiple(number, 3)) return false;
            if (IsMultiple(number, 5)) return false;
            if (IsMultiple(number, 7)) return false;

            for (long divisor = 11; divisor <= maxDivisor; divisor += 2) if (IsMultiple(number, divisor)) return false;
            return true;
        }

        /// <summary>
        /// Determine is a specific number is not prime
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsComposite(long number)
        {
            return !IsPrime(number);
        }

        /// <summary>
        /// Calculate x to the power y
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="exponent">The exponent</param>
        /// <returns>The answer</returns>
        public static long Power(long number, long exponent)
        {
            if (exponent.Equals(0)) return 1;
            if (exponent.Equals(1)) return number;

            long result = number;
            for (long index = 2; index <= exponent; index++)
                result *= number;
            return result;
        }

        /// <summary>
        /// Calculate x to the power y
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="exponent">The exponent</param>
        /// <returns>The answer</returns>
        public static ReallyBigInt Power(ReallyBigInt number, ReallyBigInt exponent)
        {
            if (exponent.value.Equals("0")) return new ReallyBigInt("1");
            if (exponent.value.Equals("1")) return number;

            ReallyBigInt result = number;
            for (ReallyBigInt index = new ReallyBigInt("2"); index.LessThanOrEqual(exponent); index = index.Addition(new ReallyBigInt("1")))
                result = result.Multiplication(number);
            return result;
        }

        /// <summary>
        /// This method returns a collection of factors for a given number
        /// This method is being deprecated!
        /// </summary>
        /// <param name="number">The number being factored</param>
        /// <returns>Collection of factors</returns>
        public static List<long> GetFactors(long number)
        {
            List<long> primeNumbers = MathLibrary.GetPrime(10000); // (number / 2);
            return GetFactors(number, primeNumbers);
        }

        /// <summary>
        /// This method returns a collection of factors for a given number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="primeNumbers"></param>
        /// <returns></returns>
        public static List<long> GetFactors(long number, List<long> primeNumbers)
        {
            List<long> factors = new List<long>();

            foreach (long primeNumber in primeNumbers)
            {
                if (Math.Sqrt((double)number) < primeNumber) break;
                if (IsMultiple(number, primeNumber))
                {
                    factors.Add(primeNumber);
                    long nextNumber = number / primeNumber;
                    if (primeNumbers.Contains(nextNumber))
                        factors.Add(nextNumber);            // When the next number prime, we are done
                    else
                        factors.AddRange(GetFactors(nextNumber, primeNumbers));
                    break;
                }
            }

            return factors;
        }

        /// <summary>
        /// This method returns a collection of factors for a given number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="primeNumbers"></param>
        /// <returns></returns>
        public static List<long> GetDistinctFactors(long number, List<long> primeNumbers)
        {
            List<long> factors = MathLibrary.GetFactors(number, primeNumbers);
            return factors.Distinct().ToList();
        }

        /// <summary>
        /// Return a list that has one entry for each digit of a number
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns>The list containing the digits</returns>
        public static List<long> GetDigits(long number)
        {
            List<long> digits = new List<long>();
            long workNumber = number;

            for (int index = 0; index < number.ToString().Length; index++)
            {
                digits.Add(workNumber % 10);
                workNumber /= 10;
            }
            return digits;
        }

        /// <summary>
        /// This method returns a collection of divisors for a given number
        /// </summary>
        /// <param name="number">The number being factored</param>
        /// <returns>Collection of divisors</returns>
        public static List<long> GetDivisors(long number)
        {
            List<long> divisors = new List<long>();
            long limit = (long)Math.Ceiling(Math.Sqrt((double)number));

            for (long divisor = 1; divisor <= limit; divisor++)
            {
                if (IsMultiple(number, divisor))
                {
                    divisors.Add(divisor);
                    long quotient = number / divisor;
                    if (divisor != quotient & number != divisor) divisors.Add(quotient);
                }
            }

            return divisors;
        }

        /// <summary>
        /// Reverse the order of digits in an integer such that 1234 becomes 4321
        /// </summary>
        /// <param name="number">The number to reverse</param>
        /// <returns>The number with digits reversed</returns>
        public static long ReverseDigits(long number)
        {
            long result = 0;
            long workNumber = number;

            while (workNumber > 0)
            {
                long remainder = workNumber % 10;
                result = (result * 10) + remainder;
                workNumber /= 10;
            }

            return result;
        }

        /// <summary>
        /// Return the square of a number
        /// </summary>
        /// <param name="number">the number</param>
        /// <returns>the number squared</returns>
        public static long Square(long number)
        {
            return number * number;
        }

        /// <summary>
        /// Return the sum of natural numbers
        /// </summary>
        /// <param name="number">The highest number in the sequence</param>
        /// <returns>The sum of the natural numbers</returns>
        public static long SumNatural(long number)
        {
            long result = 0;
            for (long sequence = 1; sequence <= number; sequence++) result += sequence;
            return result;
        }

        /// <summary>
        /// Return the sum of squares for natural numbers
        /// </summary>
        /// <param name="number">The highest number in the sequence</param>
        /// <returns>The sum of squares of the natural numbers</returns>
        public static long SumNaturalSquares(long number)
        {
            long result = 0;
            for (long sequence = 1; sequence <= number; sequence++) result += Square(sequence);
            return result;
        }

        /// <summary>
        /// Return the product of a series of numbers
        /// </summary>
        /// <param name="numbers">the numbers</param>
        /// <returns>the product</returns>
        public static long SeriesProduct(List<long> numbers)
        {
            long result = 1;
            foreach (long number in numbers)
            {
                if (number.Equals(0)) return 0;   // A zero will make the product zero
                result *= number;
            }
            return result;
        }

        /// <summary>
        /// Return the sum of a series of numbers
        /// </summary>
        /// <param name="numbers">the numbers</param>
        /// <returns>the sum</returns>
        public static long SeriesSum(List<long> numbers)
        {
            long result = 0;
            foreach (long number in numbers)
                result += number;
            return result;
        }

        /// <summary>
        /// Return the sum of a series of really big numbers
        /// </summary>
        /// <param name="numbers">the numbers</param>
        /// <returns>the sum</returns>
        public static ReallyBigInt SeriesSum(List<ReallyBigInt> numbers)
        {
            ReallyBigInt result = new ReallyBigInt("0");
            foreach (ReallyBigInt number in numbers)
                result = result.Addition(number);
            return result;
        }

        /// <summary>
        /// This method returns the sum of the digits for a given number.
        /// </summary>
        /// <param name="number">The number who digits are being summed</param>
        /// <returns>The sum of the digits</returns>
        public static long SumDigits(ReallyBigInt number)
        {
            long result = 0;
            for (int index = 0; index < number.value.Length; index++) result += long.Parse(number.value.Substring(index, 1));
            return result;
        }

        /// <summary>
        /// For problems that need to maintain an array to keep track of their
        /// "trials" or "attempts", this method allocates the array.
        /// </summary>
        /// <param name="thisMany">number of elements in the array</param>
        public static void SetupTrials(int thisMany)
        {
            sizeOfTrial = thisMany;
            trials = new int[sizeOfTrial];
        }

        /// <summary>
        /// Set a specific row in the trials array
        /// </summary>
        /// <param name="index">The row to set</param>
        /// <param name="value">The value to set the row to</param>
        public static void SetTrialValue(int index, int value)
        {
            trials[index] = value;
        }

        /// <summary>
        /// Get a specific row in the trials array
        /// </summary>
        /// <param name="index">The row to get</param>
        /// <returns>The value in the row</returns>
        public static long GetTrialValue(int index)
        {
            return trials[index];
        }

        /// <summary>
        /// Retrieve a list of triangle numbers
        /// </summary>
        /// <param name="max">The size of the sequence</param>
        /// <returns></returns>
        public static List<long> GetTriangle(long max)
        {
            List<long> triangleNumbers = new List<long>();
            for (long n = 1; n <= max; n++)
                triangleNumbers.Add((long)(.5 * (float)n * (float)(n + 1)));
            return triangleNumbers;
        }

        /// <summary>
        /// Retrieve a list of pentagon numbers
        /// </summary>
        /// <param name="max">The size of the sequence</param>
        /// <returns></returns>
        public static List<long> GetPentagon(long max)
        {
            List<long> pentagonNumbers = new List<long>();
            for (long n = 1; n <= max; n++)
                pentagonNumbers.Add(n*(3*n-1)/2);
            return pentagonNumbers;
        }

        /// <summary>
        /// Retrieve a list of hexagon numbers
        /// </summary>
        /// <param name="max">The size of the sequence</param>
        /// <returns></returns>
        public static List<long> GetHexagon(long max)
        {
            List<long> hexagonNumbers = new List<long>();
            for (long n = 1; n <= max; n++)
                hexagonNumbers.Add(n * (2 * n - 1));
            return hexagonNumbers;
        }

        /// <summary>
        /// This method determines the length of a Collatz sequence that starts at
        /// a specific number.
        /// </summary>
        /// <param name="number">The starting point of the sequence.</param>
        /// <returns>The length of the sequence.</returns>
        public static int CollatzLength(long number)
        {
            int length;

            // if the number is less than the array size, then check for reuse
            if (number < trials.Length)
                if (trials[number] > 0) return trials[number];

            if (IsEven(number))
                length = CollatzLength(number / 2) + 1;
            else
                length = CollatzLength(number * 3 + 1) + 1;

            // if the number is less than the array size, then store the length
            if (number < trials.Length)
                trials[number] = length;

            return length;
        }

        /// <summary>
        /// Compute the number of paths through a lattice. This method assumes the
        /// dimensions of the lattice are a square.
        /// </summary>
        /// <param name="size">Size of the lattice, i.e. 3 for a 3 x 3 (tic-tac-toe board)</param>
        /// <param name="hPosition">The current horizontal position</param>
        /// <param name="vPosition">The current vertical position</param>
        /// <returns>The number of paths coming from this point</returns>
        public static long LatticePaths(int size, int hPosition, int vPosition)
        {
            if (hPosition.Equals(size)) return 1;
            if (vPosition.Equals(size)) return 1;
            return LatticePaths(size, hPosition + 1, vPosition) + LatticePaths(size, hPosition, vPosition + 1);
        }

        /// <summary>
        /// This is a very specialized formatting method. It returns the words for numbers between one and 1,000
        /// without using spaces between words.
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns>the number written in letters</returns>
        public static string NumberAsString(int number)
        {
            string[] digits = new string[10] { null, "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] teens = new string[10] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = new string[10] { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number.Equals(1000)) return "onethousand";
            if (number.Equals(100)) return "onehundred";
            if (number < 10) return digits[number];
            if (number < 20) return teens[number - 10];
            if (number < 100) return tens[number / 10] + NumberAsString(number % 10);

            string hundredsDigit = NumberAsString(number / 100);
            int remainder = number % 100;

            if (remainder.Equals(0))
                return hundredsDigit + "hundred";
            else
                return hundredsDigit + "hundredand" + NumberAsString(remainder);
        }

        /// <summary>
        /// Calculate the factorial up to the given number
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns>The factorial</returns>
        public static ReallyBigInt BigFactorial(long number)
        {
            ReallyBigInt product = new ReallyBigInt("1");
            for (long index = 1; index <= number; index++ )
                product = product.Multiplication(new ReallyBigInt(index.ToString()));
            return product;
        }

        /// <summary>
        /// Calculate the factorial up to the given number
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns>The factorial</returns>
        public static long Factorial(long number)
        {
            long product = 1;
            for (long index = 1; index <= number; index++)
                product *= index;
            return product;
        }

        /// <summary>
        /// This is a very specilized method. It gives a score to a string by
        /// adding together number representations of each letter where A = 1,
        /// B = 2, C = 3 etc.
        /// </summary>
        /// <param name="word">The word</param>
        /// <returns>The score</returns>
        public static long WordScore(string word)
        {
            long result = 0;
            string letters = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int index = 0; index < word.Length; index++)
            {
                string letter = word.Substring(index, 1).ToUpper();
                result += letters.IndexOf(letter);
            }
            return result;
        }

        /// <summary>
        /// Implement the general quadratic formula of
        /// x² + ax + b
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>The result of the formula</returns>
        public static long GeneralQuadraticFormula(long x, long a, long b)
        {
            return (x * x) + (x * a) + b;
        }
    }
}
