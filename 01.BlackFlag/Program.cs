using System;

namespace _01.BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDays = int.Parse(Console.ReadLine());

            int plumbForDay = int.Parse(Console.ReadLine());
            double plumbForHalfday = plumbForDay * 0.5;
            
            double targetexpected = double.Parse(Console.ReadLine());

            double gatherPlunder = 0;

            

            for (int i = 1; i <= numDays; i++)
            {
                gatherPlunder += plumbForDay;

                if (i % 3 == 0)
                {
                    gatherPlunder += plumbForHalfday;
                }

                if (i % 5 == 0)
                {
                    gatherPlunder -= gatherPlunder * 0.3;
                }

            }
           
            if (gatherPlunder >= targetexpected )
            {
                Console.WriteLine($"Ahoy! {gatherPlunder:f2} plunder gained.");
            }
            else 
            {
                double percent = gatherPlunder / targetexpected * 100;
                Console.WriteLine($"Collected only {percent:f2}% of the plunder.");
            }
            
        }
    }
}
