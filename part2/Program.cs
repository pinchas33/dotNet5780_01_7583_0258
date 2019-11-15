//this program manages a calendar of holiday orders
//students names: pinchas rozenberg, ID: 206190258. yaakov gottlieb, ID: 8807583

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {
        private const int DAYS_IN_MONTH = 31;
        private const int MONTH_IN_YEAR = 12;

        static private bool[,] calendar = new bool[MONTH_IN_YEAR, DAYS_IN_MONTH];
        static private int numOfOrderedDays = 0;

        static private bool SetDate(DateTime startDate, int numOfDays)
        {       //this function sets an order in given date and number days from user
            calendar[startDate.Month - 1, startDate.Day - 1] = numOfDays == 1 ? true : false;   //in case user ordered 1 day

            for (int i = 0; i < numOfDays - 1; i++)
            {
                if (!calendar[startDate.Month - 1 + (startDate.Day + i) / DAYS_IN_MONTH, (startDate.Day + i) % DAYS_IN_MONTH])
                {
                    calendar[startDate.Month - 1 + (startDate.Day + i) / DAYS_IN_MONTH, (startDate.Day + i) % DAYS_IN_MONTH] = true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        static private void Order()
        {       //this function gets details from the user about the holiday 
            DateTime startDate;
            int numOfDays;

            Console.WriteLine("Enter a date:");
            DateTime.TryParse(Console.ReadLine(), out startDate); 
            Console.WriteLine("Enter a number of days:");
            int.TryParse(Console.ReadLine(), out numOfDays);

            numOfOrderedDays += numOfDays;
            
            if(SetDate(startDate, numOfDays))
            {
                Console.WriteLine("Your request was accepted");
            }
            else
            {
                Console.WriteLine("Your request was rejected");
            }
        }

        static private void PrintOrderedDates()
        {       //this function prints all ordered dates
            int daysCounter = 0;
            int firstMonth = 0, firstDay = 0;

            for(int i = 0; i < MONTH_IN_YEAR; i++)
            {
                for(int j = 0; j < DAYS_IN_MONTH; j++)
                {
                    if (calendar[i, j])
                    {       //keep first date and count
                        firstDay = daysCounter == 0 ? j : firstDay;
                        firstMonth = daysCounter == 0 ? i + 1 : firstMonth;
                        daysCounter++;
                    }

                    if (daysCounter > 0 && !calendar[i, j])
                    {       //when a swquence of days stops
                        int lastDate = firstDay + daysCounter > DAYS_IN_MONTH ? (firstDay + daysCounter) % DAYS_IN_MONTH : firstDay + daysCounter;
                        int lastMonth = firstDay + daysCounter > DAYS_IN_MONTH ? firstMonth + (firstDay + daysCounter) / DAYS_IN_MONTH : firstMonth;
                        firstDay = daysCounter == 1 ? lastDate : firstDay;
                        Console.WriteLine(firstDay + "/" + firstMonth + " - " + lastDate + "/" + lastMonth);
                        daysCounter = 0;
                    }
                }
            }      
        }

        static private void PrintPercentOfOrderedDates()
        {       //this function prints the number of ordered days and it's percent
            Console.WriteLine("{0}{1}", "Number of ordered dates: ", numOfOrderedDays);
            Console.WriteLine("{0}{1}", "Percent of ordered days: ", (100 * ((float)numOfOrderedDays / 372)));
        }

        static void Main(string[] args)
        {
            int choise = 0;
            while (choise != 4)
            {
                Console.WriteLine("Enter 1 to order a holiday");
                Console.WriteLine("Enter 2 to print ordered dates");
                Console.WriteLine("Enter 3 to print sum of ordered days");
                Console.WriteLine("Enter 4 to exit");
                int.TryParse(Console.ReadLine(), out choise);

                switch (choise)
                {
                    case 1: Order(); break;
                    case 2: PrintOrderedDates(); break;
                    case 3: PrintPercentOfOrderedDates(); break;
                }
            }   
        }
    }
}
