using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputt = Console.ReadLine();
            Dictionary<string, int> cityPop = new Dictionary<string, int>();
            Dictionary<string, int> cityGold = new Dictionary<string, int>();
            while (inputt != "Sail")
            {
                string[] input = inputt.Split("||", StringSplitOptions.RemoveEmptyEntries);
               
                string cityName = input[0];
               

                if (cityPop.ContainsKey(cityName))
                {
                    int population = int.Parse(input[1]);
                    int gold = int.Parse(input[2]);
                    cityPop[cityName] += population;
                    cityGold[cityName] += gold;
                }
                else
                {
                    int population = int.Parse(input[1]);
                    int gold = int.Parse(input[2]);
                    cityPop[cityName] = population;
                    cityGold[cityName] = gold;
                }
                inputt = Console.ReadLine();
            }


            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] inputEnd = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string newTypeCommand = inputEnd[0];
                if (newTypeCommand == "Plunder")
                {
                    string cityName = inputEnd[1];
                    int population = int.Parse(inputEnd[2]);
                    int gold = int.Parse(inputEnd[3]);

                    cityPop[cityName] -= population;
                    cityGold[cityName] -= gold;
                    Console.WriteLine($"{cityName} plundered! {gold} gold stolen, {population} citizens killed.");
                    if (cityPop[cityName] == 0 || cityGold[cityName] == 0)
                    {
                        cityPop.Remove(cityName);
                        Console.WriteLine($"{cityName} has been wiped off the map!");
                    }
                }
                else if (newTypeCommand == "Prosper")
                {
                    string cityName = inputEnd[1];
                    int gold = int.Parse(inputEnd[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        cityGold[cityName] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {cityName} now has {cityGold[cityName]} gold.");

                    }
                }
                command = Console.ReadLine(); 
            }
            if (cityPop.Count == 0)
            {

                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
                return;
            }

            if (command == "End")
            {
                Console.WriteLine($"Ahoy, Captain! There are {cityPop.Count} wealthy settlements to go to:");
                foreach (var item in cityPop)
                {
                    foreach (var curr in cityGold)
                    {
                        if (item.Key == curr.Key)
                        {
                            Console.WriteLine($"{item.Key} -> Population: {item.Value} citizens, Gold: {curr.Value} kg");
                        }
                    }
                }
                
            }
           
        }
    }
}
