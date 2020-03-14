
using System.Collections.Generic;

namespace EulerLibrary
{
    public static class Utilities
    {
        /// <summary>
        /// Convert a timestamp of milliseconds to a formattted time amount in the form HH:MM:SS.mmmm
        /// </summary>
        /// <param name="incomingTime">Number of milliseconds</param>
        /// <returns>Formatted amount of time</returns>
        public static string FormatMilliseconds(long totalMilliseconds)
        {

            long milliseconds = totalMilliseconds % 1000;
            long totalseconds = totalMilliseconds / 1000;
            long seconds = totalseconds % 60;
            long totalminutes = totalseconds / 60;
            long minutes = totalminutes % 60;
            long hours = totalminutes / 60;

            string formatSeconds = seconds.ToString();
            string formatMinutes = minutes.ToString();
            string formatHours = hours.ToString();
            string formatMilliseconds;

            if (milliseconds < 10)       formatMilliseconds = "00" + milliseconds.ToString();
            else if (milliseconds < 100) formatMilliseconds = "0" + milliseconds.ToString();
            else                         formatMilliseconds = milliseconds.ToString();


            if (seconds < 10) formatSeconds = "0" + formatSeconds;
            if (minutes < 10) formatMinutes = "0" + formatMinutes;
            if (hours < 10) formatHours = "0" + formatHours;

            return formatHours + ":" + formatMinutes + ":" + formatSeconds + "." + formatMilliseconds;

        }

        /// <summary>
        /// Check a list of number to see if there are duplicates
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static bool HasDuplicate(List<long> numbers)
        {
            int[] digits = new int[10];

            foreach (long number in numbers)
                if (digits[number] > 0)
                    return true;
                else
                    digits[number] = 1;

            return false;
        }

        /// <summary>
        /// Check a list of number to see if any are zero
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static bool HasZeros(List<long> numbers)
        {
            foreach (long number in numbers)
                if (number.Equals(0)) return true;
            return false;
        }

        /// <summary>
        /// append two lists together
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static List<long> CombineLists(List<long> list1, List<long> list2)
        {
            foreach (long item in list2) list1.Add(item);
            return list1;
        }

        /// <summary>
        /// Check a list of numbers to see if any are bigger than the number of elements in
        /// the list. This is used for pandigital checking.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static bool HasGreaterThanLength(List<long> numbers)
        {
            foreach (long number in numbers)
                if (number > numbers.Count) return true;
            return false;
        }
    }
}
