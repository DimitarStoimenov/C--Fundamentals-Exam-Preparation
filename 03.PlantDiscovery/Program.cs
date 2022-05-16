using System;
using System.Linq;
using System.Collections.Generic;

namespace _3.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> plRarity = new Dictionary<string, int>();
            Dictionary<string, List< double>> plRating = new Dictionary<string, List<double>>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int rarity = int.Parse(input[1]);
                if (plRarity.ContainsKey(name))
                {
                    plRarity[name] = rarity;
                }
                else
                {
                    plRarity[name] = rarity;
                }
            }
                string command = Console.ReadLine();
              
                while (command != "Exhibition")
            {
                string[] rawCommand = command.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string typeCommand = rawCommand[0];
                string[] arrgInput = rawCommand[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string plantName = arrgInput[0];
                if (!plRarity.ContainsKey(plantName))
                {
                    Console.WriteLine("error");
                    command = Console.ReadLine();
                    continue;

                }



                if (typeCommand == "Rate")
                    {
                       
                        double rating = double.Parse(arrgInput[1]);
                        if (!plRating.ContainsKey(plantName))
                        {
                            plRating[plantName] = new List<double>();

                        }
                        plRating[plantName].Add(rating);
                    }
                    else if (typeCommand == "Update")
                    {
                         int newrarity = int.Parse(arrgInput[1]);
                           if (!plRarity.ContainsKey(plantName))
                           {
                            Console.WriteLine("error");
                            

                           }
                        
                        plRarity[plantName] = newrarity;
                    }

                    if (typeCommand == "Reset")
                    {
                        if (!plRarity.ContainsKey(plantName))
                        {
                            Console.WriteLine("error");
                            

                        }
                        if (plRating.ContainsKey(plantName))
                        {
                            plRating[plantName].Clear();
                        }
                    }

                    command = Console.ReadLine();
                }

            Console.WriteLine("Plants for the exhibition:");

            foreach (KeyValuePair<string, int> kvp in plRarity)
            {
                double average = 0;
                if (plRating.ContainsKey(kvp.Key) && plRating[kvp.Key].Any())
                {
                    average = plRating[kvp.Key].Average();
                    Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value}; Rating: {average:f2}");
                }
               
            }
            
        }
    }
}
