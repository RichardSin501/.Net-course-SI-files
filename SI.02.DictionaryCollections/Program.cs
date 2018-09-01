using System.Collections;

namespace SI._02.DictionaryCollections
{
    internal static class HashTableHandsOn
    {
        private static void Main()
        {
            var hashtable = new Hashtable();
            var numStrings = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            var textStrings = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            for (int i = 0; i < numStrings.Length; i++)
            {
                hashtable.Add(numStrings[i], textStrings[i]);
            }

            var stringOfNumbers = "0123456789";

            foreach (char c in stringOfNumbers)
            {
                string currentKey = "" + c;
                if (hashtable.ContainsKey(currentKey))
                {
                    System.Console.WriteLine(hashtable[currentKey]);
                }
            }
        }
    }
}