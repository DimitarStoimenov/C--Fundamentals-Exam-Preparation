using System;

namespace _01.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double taxesCount = 0.0;
            double totalPrice = 0.0;
            double totalPriceWithoutTaxes = 0.0;
            double totalTaxes = 0.0;

            while (command != "special" && command != "regular")
            {
                double input = double.Parse(command);

               


                if (input <= 0)
                {
                    Console.WriteLine("Invalid price!");

                }
                else
                {
                    taxesCount = input * 0.2;
                    totalPrice += input + taxesCount;
                    totalTaxes += taxesCount;
                    totalPriceWithoutTaxes += input;

                    

                }
                

                command = Console.ReadLine();
            }

            if (totalPrice <= 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            if (command == "special")
            {
                totalPrice -= totalPrice * 0.10;
                Console.WriteLine($"Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPriceWithoutTaxes:f2}$");
                Console.WriteLine($"Taxes: {totalTaxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPrice:f2}$");
            }
            else 
            {
                Console.WriteLine($"Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPriceWithoutTaxes:f2}$");
                Console.WriteLine($"Taxes: {totalTaxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPrice:f2}$");
            }
        }
    }
}
