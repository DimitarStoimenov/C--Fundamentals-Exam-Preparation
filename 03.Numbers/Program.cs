using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            List<int> output = new List<int>();
            double average = (double)input.Average();

            foreach (var item in input)
            {
                if (item > average)
                {
                    output.Add(item);
                }
            }
            if (output.Count == 0)
            {
                Console.WriteLine("No");
            }

            else

            { 
                var result = output.OrderByDescending(x => x).Where(x => x > average).Take(5).ToList();

                Console.WriteLine(string.Join(" ", result));
            }

            
        }
    }
}
