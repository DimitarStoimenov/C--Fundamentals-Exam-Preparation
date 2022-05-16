using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.AdastraProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string inputPattern = @"([\||#])(?<name>[A-Za-z\s*]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<nutrition>\d+)\1";
            int totalNutrition = 0;
            int sum = 0;
            MatchCollection matches = Regex.Matches(input, inputPattern);
           
           
            foreach (Match item in matches)
            {
               
                int nutrition = int.Parse(item.Groups["nutrition"].Value);

                totalNutrition += nutrition;

            }
            sum = totalNutrition / 2000;
            Console.WriteLine($"You have food to last you for: {sum} days!");
            foreach (Match item in matches)
            {
                string name = item.Groups["name"].Value;
                string date = item.Groups["date"].Value;
                int nutrition = int.Parse(item.Groups["nutrition"].Value);

                Console.WriteLine($"Item: {name}, Best before: {date}, Nutrition: {nutrition}");
            }


           
            

        }
    }
}
