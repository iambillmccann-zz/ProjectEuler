using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    public class NamesScores : IEulerSolution
    {
        /// <summary>
        /// Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, 
        /// begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value 
        /// by its alphabetical position in the list to obtain a name score.
        /// 
        /// For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 
        /// 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.
        /// What is the total of all the name scores in the file?
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            long result = 0;
            string text = System.IO.File.ReadAllText(@"C:\Users\Bill\Downloads\p022_names.txt").Replace('"', ' ');
            string[] names = text.Split(',');
            int count = 0;

            foreach (string name in names)
            {
                string trimmedName = name.TrimStart(' ');
                trimmedName = trimmedName.TrimEnd(' ');
                names[count++] = trimmedName;
            }

            Array.Sort(names);
            int order = 1;
            foreach (string name in names)
                result += (MathLibrary.WordScore(name) * order++);

            return result.ToString();
        }
    }
}
