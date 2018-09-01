using System;
using System.Collections.Generic;
using System.Linq;

namespace SI._01.LINQ
{
    internal static class Program
    {
        private static void Main()
        {
            string[] words = { "these", "are", "strings", "in", "an", "array" };

            var shortWords = from word in words where word.Length <= 3 select word;

            Console.WriteLine(string.Join(", ", shortWords));

            shortWords = words.Where(w => w.Length <= 3);

            Console.WriteLine(string.Join(", ", shortWords));
        }
    }
}