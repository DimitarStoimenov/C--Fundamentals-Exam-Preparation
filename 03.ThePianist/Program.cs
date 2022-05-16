using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Dictionary<string, string> pieceComp = new Dictionary<string, string>();
            Dictionary<string, string> piecekey = new Dictionary<string, string>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string piece = input[0];
                string composer = input[1];
                string key = input[2];

                pieceComp[piece] = composer;
                piecekey[piece] = key;


            }
            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] rawCommand = command.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string typeCommand = rawCommand[0];
                if (typeCommand == "Add")
                {
                    string piece = rawCommand[1];
                    string composer = rawCommand[2];
                    string key = rawCommand[3];

                    if (pieceComp.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        pieceComp[piece] = composer;
                        piecekey[piece] = key;
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }

                }
                if (typeCommand == "Remove")
                {
                    string piece = rawCommand[1];
                    if (piecekey.ContainsKey(piece))
                    {
                        piecekey.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                if (typeCommand == "ChangeKey")
                {
                    string piece = rawCommand[1];
                    string key = rawCommand[2];

                    if (piecekey.ContainsKey(piece))
                    {
                        piecekey[piece] = key;
                        Console.WriteLine($"Changed the key of {piece} to {key}!");

                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }

                }

                command = Console.ReadLine();
            }

            if (command == "Stop")
            {
                foreach (var item in pieceComp)
                {
                    foreach (var curr in piecekey)
                    {
                        if (item.Key == curr.Key)
                        {
                            Console.WriteLine($"{item.Key} -> Composer: {item.Value}, Key: {curr.Value}");
                        }
                    }

                }

            }
        }
    }
}
