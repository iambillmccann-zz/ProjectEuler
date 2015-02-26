using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerLibrary.Problems
{
    /// <summary>
    /// In England the currency is made up of pound, £, and pence, perimeter, and there are eight coins in general circulation:
    ///
    /// 1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
    ///
    /// It is possible to make £2 in the following way:
    ///
    /// 1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
    ///
    /// How many different ways can £2 be made using any number of coins?
    /// </summary>
    public class CoinSums : IEulerSolution
    {
        private Dictionary<string, int[]> combinations;

        private Dictionary<string, int[]> combinations1p;
        private Dictionary<string, int[]> combinations2p;
        private Dictionary<string, int[]> combinations5p;
        private Dictionary<string, int[]> combinations10p;
        private Dictionary<string, int[]> combinations20p;
        private Dictionary<string, int[]> combinations50p;
        private Dictionary<string, int[]> combinationsE1;
        private Dictionary<string, int[]> combinationsE2;

        private int amount;

        /// <summary>
        /// The constructor sets the amount we are finding combinations for and initializes
        /// properties.
        /// </summary>
        /// <param name="amount"></param>
        public CoinSums(int amount)
        {
            this.amount = amount;
            combinations = new Dictionary<string, int[]>();
        }

        /// <summary>
        /// Return a string that represent the combination of the coins
        /// </summary>
        /// <param name="coins">An array of coins</param>
        /// <returns>String key</returns>
        private string GetCoinKey(int[] coins)
        {
            string result = null;
            Array.Sort(coins);
            foreach (int coin in coins) result = result + "|" + coin.ToString();
            return result;
        }

        /// <summary>
        /// Merge to sets of coins together
        /// </summary>
        /// <param name="set1">A set of coin combinations</param>
        /// <param name="set2">A second set of coin combinations</param>
        /// <returns>The merged set of coin combinations</returns>
        private Dictionary<string, int[]> MergeCombinations(Dictionary<string, int[]> set1, Dictionary<string, int[]> set2)
        {
            Dictionary<string, int[]> combination = new Dictionary<string, int[]>();
            foreach (KeyValuePair<string, int[]> series1 in set1)
                foreach (KeyValuePair<string, int[]> series2 in set2)
                {
                    int[] newSet = new int[series1.Value.Length + series2.Value.Length];
                    for (int index = 0; index < series1.Value.Length; index++) newSet[index] = series1.Value[index];
                    for (int index = 0; index < series2.Value.Length; index++) newSet[series1.Value.Length + index] = series2.Value[index];
                    string coinKey = GetCoinKey(newSet);
                    if (!combination.ContainsKey(coinKey)) combination.Add(coinKey, newSet);
                }
            return combination;
        }

        /// <summary>
        /// Append one set of coin combinations to the end of the list of another, without copying duplicates
        /// </summary>
        /// <param name="set1">A set of coin combinations</param>
        /// <param name="set2">A second set of coin combinations</param>
        /// <returns>Combined lists</returns>
        private Dictionary<string, int[]> CombineCombinations(Dictionary<string, int[]> set1, Dictionary<string, int[]> set2)
        {
            foreach (KeyValuePair<string, int[]> series in set2)
            {
                if (!set1.ContainsKey(series.Key)) set1.Add(series.Key, series.Value);
            }
            return set1;
        }

        private Dictionary<string, int[]> GetCombinations1p(int coin)
        {
            Dictionary<string, int[]> combinations = new Dictionary<string, int[]>();
            int[] coins;
            string coinKey;

            coins = new int[1] { 1 };
            coinKey = GetCoinKey(coins);
            combinations.Add(coinKey, coins);

            return combinations;
        }

        private Dictionary<string, int[]> GetCombinations2p(int coin)
        {
            Dictionary<string, int[]> combinations = new Dictionary<string, int[]>();
            int[] coins;
            string coinKey;

            coins = new int[1] { 2 };
            coinKey = GetCoinKey(coins);
            combinations.Add(coinKey, coins);
            combinations = CombineCombinations(combinations,
                                               MergeCombinations(getCombinations(1),
                                                                 getCombinations(1)));

            return combinations;
        }

        private Dictionary<string, int[]> GetCombinations5p(int coin)
        {
            Dictionary<string, int[]> combinations = new Dictionary<string, int[]>();
            int[] coins;
            string coinKey;

            coins = new int[1] { 5 };
            coinKey = GetCoinKey(coins);
            combinations.Add(coinKey, coins);
            combinations = CombineCombinations(combinations,
                                               MergeCombinations(getCombinations(1),
                                                                 MergeCombinations(getCombinations(2),
                                                                                   getCombinations(2))));

            return combinations;
        }

        private Dictionary<string, int[]> GetCombinations10p(int coin)
        {
            Dictionary<string, int[]> combinations = new Dictionary<string, int[]>();
            int[] coins;
            string coinKey;

            coins = new int[1] { 10 };
            coinKey = GetCoinKey(coins);
            combinations.Add(coinKey, coins);
            combinations = CombineCombinations(combinations,
                                               MergeCombinations(getCombinations(5),
                                                                 getCombinations(5)));
            combinations = CombineCombinations(combinations,
                                               MergeCombinations(getCombinations(2),
                                                                 MergeCombinations(getCombinations(2),
                                                                                   MergeCombinations(getCombinations(2),
                                                                                                     MergeCombinations(getCombinations(2),
                                                                                                                       getCombinations(2))))));

            return combinations;
        }

        private Dictionary<string, int[]> GetCombinations20p(int coin)
        {
            Dictionary<string, int[]> combinations = new Dictionary<string, int[]>();
            int[] coins;
            string coinKey;

            coins = new int[1] { 20 };
            coinKey = GetCoinKey(coins);
            combinations.Add(coinKey, coins);
            combinations = CombineCombinations(combinations,
                                               MergeCombinations(getCombinations(10),
                                                                 getCombinations(10)));

            return combinations;
        }

        private Dictionary<string, int[]> GetCombinations50p(int coin)
        {
            Dictionary<string, int[]> combinations = new Dictionary<string, int[]>();
            int[] coins;
            string coinKey;

            coins = new int[1] { 50 };
            coinKey = GetCoinKey(coins);
            combinations.Add(coinKey, coins);
            combinations = CombineCombinations(combinations,
                                               MergeCombinations(getCombinations(10),
                                                                 MergeCombinations(getCombinations(20),
                                                                                   getCombinations(20))));

            return combinations;
        }

        private Dictionary<string, int[]> GetCombinationsE1(int coin)
        {
            Dictionary<string, int[]> combinations = new Dictionary<string, int[]>();
            int[] coins;
            string coinKey;

            coins = new int[1] { 100 };
            coinKey = GetCoinKey(coins);
            combinations.Add(coinKey, coins);
            combinations = CombineCombinations(combinations,
                                               MergeCombinations(getCombinations(50),
                                                                 getCombinations(50)));
            combinations = CombineCombinations(combinations,
                                               MergeCombinations(getCombinations(20),
                                                                 MergeCombinations(getCombinations(20),
                                                                                   MergeCombinations(getCombinations(20),
                                                                                                     MergeCombinations(getCombinations(20),
                                                                                                                       getCombinations(20))))));

            return combinations;
        }

        private Dictionary<string, int[]> GetCombinationsE2(int coin)
        {
            Dictionary<string, int[]> combinations = new Dictionary<string, int[]>();
            int[] coins;
            string coinKey;

            coins = new int[1] { 200 };
            coinKey = GetCoinKey(coins);
            combinations.Add(coinKey, coins);
            combinations = CombineCombinations(combinations,
                                               MergeCombinations(getCombinations(100),
                                                                 getCombinations(100)));

            return combinations;
        }

        /// <summary>
        /// Get all the coin combinations for a particular coin demonination
        /// </summary>
        /// <param name="coin">The coin amount</param>
        /// <returns>A Dictionary containing the coin sequences</returns>
        public Dictionary<string, int[]> getCombinations(int coin)
        {
            Dictionary<string, int[]> combinations = new Dictionary<string, int[]>();

            switch (coin)
            {
                case 1: // A one pence coin
                    if (combinations1p == null) combinations1p = GetCombinations1p(1);
                    combinations = combinations1p;
                    break;
                case 2: // a two pence coin
                    if (combinations2p == null) combinations2p = GetCombinations2p(2);
                    combinations = combinations2p;
                    break;
                case 5: // a five pence coin
                    if (combinations5p == null) combinations5p = GetCombinations5p(5);
                    combinations = combinations5p;
                    break;
                case 10: // a ten pence coin
                    if (combinations10p == null) combinations10p = GetCombinations10p(10);
                    combinations = combinations10p;
                    break;
                case 20:
                    if (combinations20p == null) combinations20p = GetCombinations20p(20);
                    combinations = combinations20p;
                    break;
                case 50:
                    if (combinations50p == null) combinations50p = GetCombinations50p(50);
                    combinations = combinations50p;
                    break;
                case 100:
                    if (combinationsE1 == null) combinationsE1 = GetCombinationsE1(100);
                    combinations = combinationsE1;
                    break;
                case 200:
                    if (combinationsE2 == null) combinationsE2 = GetCombinationsE2(200);
                    combinations = combinationsE2;
                    break;
                default: break;
            }
            return combinations;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Compute()
        {
            combinations = getCombinations(amount);
            return combinations.Count.ToString();
        }
    }
}
