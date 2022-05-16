using System;
using System.Linq;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string command = Console.ReadLine();
            while (command != "Reveal")
            {
                string[] rawCommand = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string typeCommand = rawCommand[0];

                if (typeCommand == "InsertSpace")
                {
                    int insertSpaceIndex = int.Parse(rawCommand[1]);
                    input = input.Insert(insertSpaceIndex, " ");
                    Console.WriteLine(input);
                }
               else if (typeCommand == "Reverse")
                {
                    string substring = rawCommand[1];
                    if (input.Contains(substring))
                    {
                        int substWordIndex = input.IndexOf(substring);
                        input = input.Remove(substWordIndex, substring.Length);
                        string word = "";

                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                           word += substring[i];
                        }
                        input += word;
                        Console.WriteLine(input);
                      
                        
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
               else if (typeCommand == "ChangeAll")
                {
                    string substring = rawCommand[1];
                    string replacement = rawCommand[2];

                    if (input.Contains(substring))
                    {
                        input = input.Replace(substring, replacement);
                        Console.WriteLine(input);
                    }
                }
                command = Console.ReadLine();
            }

            if (command == "Reveal")
            {
                Console.WriteLine($"You have a new text message: {input}");
            }
        }
    }
}
