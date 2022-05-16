using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.NeedforSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Dictionary<string, int> carMileage = new Dictionary<string, int>();
            Dictionary<string, int> carFuel = new Dictionary<string, int>();

            for (int i = 0; i < num; i++)
            {
                string[] cars = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string name = cars[0];
                int mileage = int.Parse(cars[1]);
                int fuel = int.Parse(cars[2]);
                carMileage[name] = mileage;
                carFuel[name] = fuel;
            }

            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] rawCommand = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string typeCommand = rawCommand[0];
                string carName = rawCommand[1];
                if (typeCommand == "Drive")
                {

                    int distance = int.Parse(rawCommand[2]);
                    int fuel = int.Parse(rawCommand[3]);



                    if (carFuel[carName] < fuel)
                    {

                        Console.WriteLine("Not enough fuel to make that ride");
                        command = Console.ReadLine();
                        continue;

                    }

                    if (carFuel[carName] > fuel)
                    {


                        carFuel[carName] -= fuel;
                        carMileage[carName] -= distance;



                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        carMileage[carName] += distance + distance;

                        if (carMileage[carName] >= 100000)
                        {




                            Console.WriteLine($"Time to sell the {carName}!");

                            carMileage.Remove(carName);


                        }





                    }


                }
                else if (typeCommand == "Refuel")
                {
                    int refuel = int.Parse(rawCommand[2]);
                    int curr = carFuel[carName];
                    carFuel[carName] += refuel;
                    int refuieledWith = 75 - curr;
                    if (carFuel[carName] > 75)
                    {
                        carFuel[carName] = 75;
                        Console.WriteLine($"{carName} refueled with {refuieledWith} liters");
                    }
                    else
                    {
                        Console.WriteLine($"{carName} refueled with {refuel} liters");
                    }

                }
                else if (typeCommand == "Revert")
                {
                    int kilometers = int.Parse(rawCommand[2]);
                    int currKm = carMileage[carName];

                    carMileage[carName] -= kilometers;
                    int diff = currKm - carMileage[carName];

                    if (carMileage[carName] < 10000)
                    {
                        carMileage[carName] = 10000;
                    }

                    else
                    {
                        Console.WriteLine($"{carName} mileage decreased by {diff} kilometers");
                    }

                }


                command = Console.ReadLine();
            }
            foreach (var item in carMileage)
            {
                foreach (var curr in carFuel)
                {
                    if (curr.Key == item.Key)
                    {
                        Console.WriteLine($"{item.Key} -> Mileage: {item.Value} kms, Fuel in the tank: {curr.Value} lt.");
                    }

                }





            }
        }
    }
}
