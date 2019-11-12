using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_01_7583_0258
{
    class Program
    {
        static void Main(string[] arg)
        {
            Random rand = new random();
            int[] A = new int[20]; 
            int[] B = new int[20]; 
            for (int i = 0; i < 20; i++)
            {
                A[i] = rand.Next(18, 123);
                B[i] = rand.Next(18, 123);
            }

        }
    }
}
