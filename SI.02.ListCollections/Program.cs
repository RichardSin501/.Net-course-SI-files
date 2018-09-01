using System;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;

namespace SI._02.ListCollections
{
    internal static class LookupCollectionsHandsOn
    {
        private static void Main()
        {
            var listDic = new ListDictionary(StringComparer.InvariantCultureIgnoreCase);

            listDic.Add("United States", "Estados Unidos");
            listDic.Add("Canada", "Canadá");
            listDic.Add("Spain", "España");

            System.Console.WriteLine(
                $"Spanish versions: Spain: {listDic["spain"]}, Canada: {listDic["canada"]}");
        }
    }
}