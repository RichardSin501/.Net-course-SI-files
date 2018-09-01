using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace SI._02.GenericCollections
{
    internal static class GenericCollectionsHandsOn
    {
        private static void Main(string[] args)
        {
            var dictOfCountries = new Dictionary<int, string>()
            {
                [1] = "Hungary",
                [2] = "Slovakia",
                [3] = "Greenland"
            };

            WriteLine($"At country code'1' : {dictOfCountries[1]}\n");
            foreach (var kvp in dictOfCountries)
            {
                WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }
    }
}