using System;
using System.Linq;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitCoins = 0;
            int currBit = 0;
            
            int counter = 0;

            string[] rooms = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < rooms.Length; i++)
            {
                counter++;
                string[] command = rooms[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string typeCommand = command[0];

                if (typeCommand == "potion")
                {
                    int diff = 100 - health; 
                    health += int.Parse(command[1]);
                    if (health > 100)
                    {  
                        health = 100;
                        Console.WriteLine($"You healed for {diff} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {command[1]} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }

                }

                else if (typeCommand == "chest")
                {
                     currBit = int.Parse(command[1]);
                    bitCoins += currBit;
                    Console.WriteLine($"You found {currBit} bitcoins.");

                }

                else
                {
                    int monstersAttack = int.Parse(command[1]);
                    health -= monstersAttack;
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {typeCommand}.");
                        Console.WriteLine($"Best room: {counter}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {typeCommand}.");

                        
                    }
                    
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitCoins}");
            Console.WriteLine($"Health: {health}");
            
        }
    }
}
