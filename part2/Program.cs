using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {
        static private bool[,] calendar = new bool[12, 31];

        static private void SetDate(DateTime startDate, int numOfDays)
        {
            for (int i = 1; i < numOfDays - 1; i++)
            {
                if (!calendar[startDate.Month - 1, startDate.Day + i])
                {
                    calendar[startDate.Month - 1, startDate.Day + i] = true;
                }
            }
        }

        static void Main(string[] args)
        {
            DateTime startDate;
            Console.WriteLine("Enter a date and number of days: ");
            DateTime.TryParse(Console.ReadLine(), out startDate);
            int numOfDays;
            int.TryParse(Console.ReadLine(), out numOfDays);
            Console.WriteLine(startDate.Month + numOfDays);

            SetDate(startDate, numOfDays);

            Console.ReadKey();
            
        }
    }
}
