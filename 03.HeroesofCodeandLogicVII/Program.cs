using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.HeroesofCodeandLogicVII
{
   
    
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> outputHP = new Dictionary<string,int>();
            Dictionary<string, int> outputMP = new Dictionary<string,int>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int hp = int.Parse(input[1]);
                int mp = int.Parse(input[2]);
                outputHP[name] = hp;
                outputMP[name] = mp;
                    
                
            }

            string command = Console.ReadLine();
            
            while (command != "End")
            {
                string[] rawCommand = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string typeCommand = rawCommand[0];

                if (typeCommand == "CastSpell")
                {
                    string heroName = rawCommand[1];
                    int mpNeeded = int.Parse(rawCommand[2]);
                    string spellName = rawCommand[3];
                    if (outputMP[heroName] < mpNeeded)
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                       

                    }
                    else
                    {
                        outputMP[heroName] -= mpNeeded;
                        
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {outputMP[heroName]} MP!");
                    }

                    


                }
                else if (typeCommand == "TakeDamage")
                {
                    string heroName = rawCommand[1];
                    int demage = int.Parse(rawCommand[2]);
                    string attacker = rawCommand[3];

                    outputHP[heroName] -= demage;
                    if (outputHP[heroName] > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {demage} HP by {attacker} and now has {outputHP[heroName]} HP left!");

                    }
                    else
                    {
                        
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        outputHP.Remove(heroName);
                    }

                } 
                else if (typeCommand == "Recharge")
                {
                    string heroName = rawCommand[1];
                    int amount = int.Parse(rawCommand[2]);
                    int old = outputMP[heroName];
                    outputMP[heroName] += amount;
                    if (outputMP[heroName] > 200)
                    {
                        outputMP[heroName] = 200;
                        amount = 200 - old;

                    }
                    Console.WriteLine($"{heroName} recharged for {amount} MP!");

                } 
                else if (typeCommand == "Heal")
                {
                    string heroName = rawCommand[1];
                    int amount = int.Parse(rawCommand[2]);
                    int old = outputHP[heroName];
                    outputHP[heroName] += amount;
                    if (outputHP[heroName] > 100)
                    {   
                        outputHP[heroName] = 100;
                        amount = 100 - old;

                    }
                    Console.WriteLine($"{heroName} healed for {amount} HP!");
                }

                command = Console.ReadLine();
            }
            
            foreach (var item in outputHP)
            {
                
                if (item.Value > 0)
                {
                    
                    Console.WriteLine(item.Key);
                    Console.WriteLine($"  HP: {item.Value}");

                    foreach (var curr in outputMP)
                    {
                        if (curr.Key == item.Key)
                        {
                            Console.WriteLine($"  MP: {curr.Value}");
                        }
                    }
                    
                }
                
            }
        }
    }
}
