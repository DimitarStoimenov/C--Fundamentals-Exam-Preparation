using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialLoot = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> removed = new List<string>();
            string command = Console.ReadLine();
           
            while (command != "Yohoho!")
            {
                string[] rawCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string typeCommand = rawCommand[0];

                if (typeCommand == "Loot")
                {
                   
                    

                   

                    for (int i = 1; i < rawCommand.Length; i++)
                    {
                        if (!initialLoot.Contains(rawCommand[i]))
                        {
                            initialLoot.Insert(0, rawCommand[i]);

                        }
                    }

                   
                }
                else if (typeCommand == "Drop")
                {
                    int index = int.Parse(rawCommand[1]);
                    if (index >= 0 && index < initialLoot.Count)
                    {
                        string curr = initialLoot[index];
                        initialLoot.RemoveAt(index);
                        initialLoot.Add(curr);
                    }

                    break;


                }
                else if (typeCommand == "Steal")
                {
                    int count = int.Parse(rawCommand[1]);
                    
                    for (int i = 0; i < count; i++)
                    {
                        
                        string last = initialLoot.Last();
                        removed.Add(last);
                        initialLoot.Remove(last);
                        
                    }
                   


                }

                command = Console.ReadLine();
            }
            double lenght = 0;
            foreach (var item in initialLoot)
            {
                lenght += item.Length;
            }

            lenght = lenght / initialLoot.Count;
            if (initialLoot.Count == 0)
            {
                removed.Reverse();
                Console.WriteLine($"{string.Join(", ", removed)}");
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                removed.Reverse();
                Console.WriteLine($"{string.Join(", ", removed)}");

                Console.WriteLine($"Average treasure gain: {lenght:f2} pirate credits.");
            }
        }
    }
}
