using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string inputPattern = @"(=|\/){1}(?<name>[A-Z]{1}[A-Za-z]{2,})\1";
            int totalCount = 0;

            MatchCollection matches = Regex.Matches(input, inputPattern);

            List<string> destinations = new List<string>();

            foreach (Match item in matches)
            {
                string name = item.Groups["name"].Value;
                destinations.Add(name);
                int lenght = name.Length;
                totalCount += lenght;
            }
            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {totalCount}");
            


        }
    }
}
