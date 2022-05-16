using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sectionsPiratShip = Console.ReadLine().Split(">", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] sectionsWarShip = Console.ReadLine().Split(">", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int maxHealth = int.Parse(Console.ReadLine());
            

            string command = Console.ReadLine();

            while (command != "Retire")
            {
                string[] rawCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string typeCommand = rawCommand[0];

                if (typeCommand == "Fire")
                {
                    int index = int.Parse(rawCommand[1]);
                    int damage = int.Parse(rawCommand[2]);

                    if (index >= 0 && index < sectionsWarShip.Length)
                    {
                        sectionsWarShip[index] -= damage;
                        if (sectionsWarShip[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                    
                 
                    


                }
                else if (typeCommand == "Defend")
                {
                    int startIndex = int.Parse(rawCommand[1]);
                    int endIndex = int.Parse(rawCommand[2]);
                    int damage = int.Parse(rawCommand[3]);

                    if (startIndex >= 0 && startIndex < 
                        sectionsPiratShip.Length && 
                        endIndex >= 0 && endIndex < sectionsPiratShip.Length)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sectionsPiratShip[i] -= damage;

                            if (sectionsPiratShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }

                    }

                }
                else if (typeCommand == "Repair")
                
                {
                    int index = int.Parse(rawCommand[1]);
                    int health = int.Parse(rawCommand[2]);
                    if (index >= 0 && index <= sectionsPiratShip.Length)
                    {
                        if (sectionsPiratShip[index] + health < maxHealth)
                        {
                            sectionsPiratShip[index] += health;
                        }
                        else
                        {
                            sectionsPiratShip[index] = health;
                        }
                        
                    }
                    
                }
                if (typeCommand == "Status")
                {
                    List<int> toRepare = new List<int>();
                      
                    
                        for (int i = 0; i < sectionsPiratShip.Length; i++)
                        {
                            double percent = maxHealth * 0.2;
                            if (sectionsPiratShip[i] < percent)
                            {
                                toRepare.Add(sectionsPiratShip[i]);
                            }

                        }
                        Console.WriteLine($"{toRepare.Count} sections need repair.");
                        

                    
                }
                



                command = Console.ReadLine();
            }


            double pirateSum = sectionsPiratShip.Sum();
            double WarSum = sectionsWarShip.Sum();
            Console.WriteLine($"Pirate ship status: {pirateSum}");
            Console.WriteLine($"Warship status: {WarSum}");
            


        }
    }
}
