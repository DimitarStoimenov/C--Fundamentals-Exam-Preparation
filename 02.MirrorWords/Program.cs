using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string inputPattern = @"(#|@)(?<word>[A-Za-z]{3,})\1\1(?<secword>[A-Za-z]{3,})\1";
            List<string> output = new List<string>();

            MatchCollection matches = Regex.Matches(input, inputPattern);

            if (matches.Count != 0)
            {


                foreach (Match item in matches)
                {
                    string firstWord = item.Groups["word"].Value;
                    string secondWord = item.Groups["secword"].Value;
                    string reversedWord = string.Join("",secondWord.Reverse());

                    if (reversedWord == firstWord)
                    {
                        output.Add($"{firstWord} <=> {secondWord}");
                    }
                    



                }
                

                if (output.Count > 0)
                {
                    Console.WriteLine($"{matches.Count} word pairs found!");
                    Console.WriteLine($"The mirror words are: ");
                    Console.WriteLine($"{string.Join(", ", output)}");
                }

            }
            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            if (output.Count == 0)
            {
                if (matches.Count != 0)
                {
                    Console.WriteLine($"{matches.Count} word pairs found!");
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }
                
            }
           
        }
    }
}
