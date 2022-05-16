using System;

namespace _01.Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int wonBattels = 0;

            while (command != "End of battle")
            {
                int input = int.Parse(command);
                
                if (initialEnergy < input)
                {
                   
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattels} won battles and {initialEnergy} energy");
                    return;
                }
                else
                {
                    initialEnergy -= input;
                    wonBattels++;
                    
                    if (wonBattels % 3 == 0)
                    {
                        initialEnergy += wonBattels;
                    }
                    
                }

                
                command = Console.ReadLine();
            }
            Console.WriteLine($"Won battles: {wonBattels}. Energy left: {initialEnergy}");
        }
    }
}
