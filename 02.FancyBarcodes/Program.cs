using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string inputPattern = @"@#+(?<name>[A-Z][A-Za-z\d]{4,}[A-Z])@#+";
            Dictionary<string, string> output = new Dictionary<string, string>();
            string totalCount = "";
            string nullCounter = "";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, inputPattern);
                string name = match.Groups["name"].Value;
                if (match.Success)
                {

                    foreach (char item in name)
                    {
                        if (char.IsDigit(item))
                        {

                            totalCount += item;
                            nullCounter += item;
                        }

                    }

                    if (nullCounter == "")
                    {
                        totalCount = "00";
                        output.Add(name, totalCount);
                        Console.WriteLine($"Product group: {totalCount}");
                        totalCount = "";


                    }
                    else
                    {
                        output.Add(name, totalCount);
                        Console.WriteLine($"Product group: {totalCount}");
                        totalCount = "";
                        nullCounter = "";
                    }




                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }




        }
    }
}
