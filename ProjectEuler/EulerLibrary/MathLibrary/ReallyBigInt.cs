using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary
{
    /// <summary>
    /// This is a special type of integer that is much larger than can be held or
    /// processed by .Net numeric types.
    /// </summary>
    public class ReallyBigInt
    {
        public string value { get; set; }

        /// <summary>
        /// Set the numeric value in the constructor
        /// </summary>
        /// <param name="theValue">The value of the integer</param>
        public ReallyBigInt(string theValue)
        {
            value = theValue;
            if (!Validate()) value = null;
        }

        /// <summary>
        /// Make sure the value is a number
        /// </summary>
        /// <returns>True if the string contains digits and false if it has other characters.</returns>
        public bool Validate()
        {
            string digits = "0123456789";

            for (int index = 0; index < value.Length; index++)
            {
                string character = value.Substring(index, 1);
                if (digits.IndexOf(character) < 0) return false;
            }
            return true;
        }

        /// <summary>
        /// Return a string of zeros
        /// </summary>
        /// <param name="zeros"></param>
        /// <returns></returns>
        private string Zeros(int size)
        {
            string zeros = null;
            for (int index = 0; index < size; index++) zeros = "0" + zeros;
            return zeros;
        }

        /// <summary>
        /// Add two ReallyBigInts together
        /// </summary>
        /// <param name="number">A number</param>
        /// <returns>The sum</returns>
        public ReallyBigInt Addition(ReallyBigInt number)
        {
            string sumString = null;
            string number1 = number.value;
            string number2 = this.value;
            int carryover = 0;

            // make the string the same size
            if (number1.Length > number2.Length) number2 = Zeros(number1.Length - number2.Length) + number2;
            if (number2.Length > number1.Length) number1 = Zeros(number2.Length - number1.Length) + number1;

            for (int index = 0; index < number1.Length; index++)
            {
                int position = (number1.Length - 1) - index;              // working from left to right
                int digit1 = int.Parse(number1.Substring(position, 1));
                int digit2 = int.Parse(number2.Substring(position, 1));
                int sumOfDigits = carryover + digit1 + digit2;
                sumString = (sumOfDigits % 10).ToString() + sumString;    // add the digit to the resulting sum
                carryover = sumOfDigits / 10;                             // make sure to account for numbers that carry over
            }

            if (carryover != 0) sumString = carryover.ToString() + sumString;

            return new ReallyBigInt(sumString);
        }

        /// <summary>
        /// Multiply two REallyBigInts
        /// </summary>
        /// <param name="number">A number</param>
        /// <returns>The product</returns>
        public ReallyBigInt Multiplication(ReallyBigInt number)
        {
            ReallyBigInt product = new ReallyBigInt("0");

            for (int index = 0; index < number.value.Length; index++)
            {
                int digit = int.Parse(number.value.Substring(number.value.Length - index - 1, 1));
                ReallyBigInt workNumber = new ReallyBigInt("0");
                for (int loop = 0; loop < digit; loop++)
                {
                    workNumber = workNumber.Addition(this);
                }
                workNumber.value = workNumber.value + Zeros(index);
                product = product.Addition(workNumber);
            }

            return product;
        }

        /// <summary>
        /// Raise a ReallyBitInt to a power
        /// </summary>
        /// <param name="exponent"></param>
        /// <returns></returns>
        public ReallyBigInt Power(ReallyBigInt exponent)
        {
            ReallyBigInt one = new ReallyBigInt("1");
            ReallyBigInt result = one;

            for (ReallyBigInt index = one; index.LessThanOrEqual(exponent); index = index.Addition(one)) 
            {
                result = result.Multiplication(this);
            }

            return result;
        }

        /// <summary>
        /// Raise a ReallyBitInt to a power
        /// </summary>
        /// <param name="exponent"></param>
        /// <returns></returns>
        public ReallyBigInt Power(long exponent)
        {
            ReallyBigInt one = new ReallyBigInt("1");
            ReallyBigInt result = one;

            for (long index = 1; index <= exponent; index++)
            {
                result = result.Multiplication(this);
            }

            return result;
        }

        /// <summary>
        /// Check to see if this number is less than another
        /// </summary>
        /// <param name="number">The number to compare</param>
        /// <returns>True if it is less</returns>
        public bool LessThan(ReallyBigInt number)
        {
            if (Compare(number) < 0) return true;
            return false;
        }

        public bool LessThanOrEqual(ReallyBigInt number)
        {
            if (Compare(number) <= 0) return true;
            return false;
        }

        /// <summary>
        /// Compare this number to another
        /// </summary>
        /// <param name="number">The number to compare</param>
        /// <returns> -1 if less than, 0 if equal, and 1 if greater</returns>
        public int Compare(ReallyBigInt number)
        {
            int result = 0;
            string string1 = value;
            string string2 = number.value;

            if (string1.Length > string2.Length)
                string2 = Zeros(string1.Length - string2.Length) + string2;
            else
                string1 = Zeros(string2.Length - string1.Length) + string1;

            for (int index = 0; index < string1.Length; index++)
            {
                int number1 = int.Parse(string1.Substring(index, 1));
                int number2 = int.Parse(string2.Substring(index, 1));

                if (number1 < number2)
                {
                    result = -1;
                    break;
                }
                if (number1 > number2)
                {
                    result = 1;
                    break;
                }
            }
            return result;
        }
    }
}
