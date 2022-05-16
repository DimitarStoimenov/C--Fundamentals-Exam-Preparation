using System;

namespace _01.BonusScoring
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfStudents = int.Parse(Console.ReadLine());
            int totalCountLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            double totalBonus = 0.0;
            double totCurr = 0.0;
            double getMax = double.MinValue;
            double maxAttendences = int.MinValue;
            for (int i = 1; i <= numOfStudents; i++)
            {
                double curr = double.Parse(Console.ReadLine());
                totalBonus = curr / totalCountLectures * (5 + additionalBonus);
                if (totalBonus >= getMax)
                {
                    getMax = totalBonus;
                   totCurr = curr;
                }
                if (curr >= maxAttendences)
                {
                    maxAttendences = curr;
                }

            }
            
           
            Console.WriteLine($"Max Bonus: {Math.Ceiling(getMax)}.");
            Console.WriteLine($"The student has attended {totCurr} lectures.");
        }
    }
}
