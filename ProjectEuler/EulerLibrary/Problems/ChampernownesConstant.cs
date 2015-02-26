
namespace EulerLibrary.Problems
{
    /// <summary>
    /// An irrational decimal fraction is created by concatenating the positive integers:
    ///
    /// 0.123456789101112131415161718192021...
    ///
    /// It can be seen that the 12th digit of the fractional part is 1.
    ///
    /// If dn represents the nth digit of the fractional part, find the value of the following expression.
    ///
    /// d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000
    ///
    /// </summary>
    public class ChampernownesConstant : IEulerSolution
    {
        public string Compute()
        {
            long result = 1;
            long decimalLength = 0;
            long count = 0;
            long d = 1;

            while (decimalLength <= 1000000)
            {
                ++count;
                long countLength = count.ToString().Length;

                if (decimalLength + countLength >= d)
                {
                    int position = (int)(d - decimalLength -1);
                    long digit = long.Parse( count.ToString().Substring(position, 1) );
                    result *= digit;
                    d *= 10;
                }

                decimalLength += countLength;
            }

            return result.ToString();
        }
    }
}
