using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// The nth term of the sequence of triangle numbers is given by, tn = ½n(n+1); 
    /// so the first ten triangle numbers are:
    ///
    /// 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
    ///
    /// By converting each letter in a word to a number corresponding to its alphabetical 
    /// position and adding these values we form a word value. For example, the word value for 
    /// SKY is 19 + 11 + 25 = 55 = t10. If the word value is a triangle number then we shall 
    /// call the word a triangle word.
    ///
    /// Using words.txt (right click and 'Save Link/Target As...'), a 16K text file containing nearly 
    /// two-thousand common English words, how many are triangle words?
    ///
    /// </summary>
    public class CodedTriangleNumbers : IEulerSolution
    {
        public const string letters = " abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// Determine the value of a word based of alphabetic sequence of its' letters
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private long WordValue(string word)
        {
            long result = 0;
            for (int index = 0; index < word.Length; index++)
                result += letters.IndexOf(word.Substring(index, 1));
            return result;
        }

        public string Compute()
        {
            List<long> triangleNumbers = MathLibrary.GetTriangle(1000);
            string text = System.IO.File.ReadAllText(@"C:\Users\Bill\Downloads\p042_words.txt").Replace('"', ' ');
            string[] words = text.Split(',');
            int count = 0;

            foreach (string word in words)
            {
                string trimmedWord = word.TrimStart(' ').TrimEnd(' ').ToLower();
                if (triangleNumbers.Contains(WordValue(trimmedWord))) count++;
            }

            return count.ToString();
        }
    }
}
