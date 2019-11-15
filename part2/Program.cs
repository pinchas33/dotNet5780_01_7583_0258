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
        static private int numOfOrderedDays = 0;

        static private bool SetDate(DateTime startDate, int numOfDays)
        {
            for (int i = 1; i < numOfDays; i++) //אני משנה: במקום "(int i = 1; i < numOfDays; i++)" אני רושם:
            {
                if (!calendar[startDate.Month - 1 + (startDate.Day + i - 1) / 31, (startDate.Day + i - 1) % 31])
                {
                    calendar[startDate.Month - 1 + (startDate.Day + i - 1) / 31, (startDate.Day + i - 1) % 31] = true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        static private void Order()
        {
            DateTime startDate;
            int numOfDays;

            Console.WriteLine("Enter a date:");
            DateTime.TryParse(Console.ReadLine(), out startDate); 
             Console.WriteLine("Enter a number of days:");
            int.TryParse(Console.ReadLine(), out numOfDays);
            numOfOrderedDays += numOfDays;
            
            if(SetDate(startDate, numOfDays))
            {
                Console.WriteLine("good");
            }
            else
            {
                Console.WriteLine("not good");
            }
            Console.ReadKey();
        }

        static private void PrintOrderedDates()
        {
            int daysCounter = 0;
            int month = 0, day = 0;

            for(int i = 0; i < 12; i++)
            {
                for(int j = 0; j < 31; j++)
                {
                    if (calendar[i, j])
                    {
                        day = daysCounter == 0 ? j : day;
                        month = daysCounter == 0 ? i + 1 : month;
                        daysCounter++;
                    }

                    if (daysCounter > 0 && !calendar[i, j])
                    {
                        int lastDate = day + daysCounter > 31 ? (day + daysCounter) % 31 : day + daysCounter;
                        int lastMonth = day + daysCounter > 31 ? month + (day + daysCounter) / 32 : month;
                        Console.WriteLine(day + "/" + month + " - " + lastDate + "/" + lastMonth);
                        daysCounter = 0;
                    }
                }
            }      
        }

        static private void PrintPercentOfOrderedDates()
        {
           // float x = (float)numOfOrderedDays / 372;
            Console.WriteLine(numOfOrderedDays);
            Console.WriteLine((100 * ((float)numOfOrderedDays / 372)));
        }

        static void Main(string[] args)
        {
            int choise = 0;
            while (choise != 4)
            {
                Console.WriteLine("enter 1 to order a holiday");
                Console.WriteLine("enter 2 print date of orders");
                Console.WriteLine("enter 3 to print sum days of orders");
                Console.WriteLine("enter 4 to exit");
                int.TryParse(Console.ReadLine(), out choise);

                switch (choise)
                {
                    case 1: Order(); break;
                    case 2: PrintOrderedDates(); break;
                    case 3: PrintPercentOfOrderedDates(); break;
                }
            }   
        }



        

   /*     static private void Print()
        {
            for(int i = 0; i < 12; i++)
            {
                for(int j = 0; j < 31; j++)
                {
                    Console.Write(calendar[i, j] + "  ");
                }
                Console.WriteLine("/n");
            }              
        }*/
    }
}
