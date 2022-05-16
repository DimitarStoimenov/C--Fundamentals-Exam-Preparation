using System;
using System.Linq;

namespace _01GuineaPig
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] rawCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string typeCommand = rawCommand[0];

                if (typeCommand == "swap")
                {
                    int index1 = int.Parse(rawCommand[1]);
                    int index2 = int.Parse(rawCommand[2]);

                    string num = input[index1];
                    input[index1] = input[index2];
                    input[index2] = num;



                }
                else if (typeCommand == "multiply")
                {
                    int index1 = int.Parse(rawCommand[1]);
                    int index2 = int.Parse(rawCommand[2]);

                    int total = int.Parse(input[index1]) * int.Parse(input[index2]);
                    input[index1] = total.ToString();

                }
                else if (typeCommand == "decrease")
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        int curr = int.Parse(input[i]);
                        curr -= 1;
                        input[i] = curr.ToString();


                    }

                }

                command = Console.ReadLine();
            }

            
                Console.Write(string.Join (", ", input));
            
        }
    }
}
