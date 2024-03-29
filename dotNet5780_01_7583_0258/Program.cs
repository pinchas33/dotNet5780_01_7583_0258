﻿//this program initializes 2 arrays and one more with the gap between the first 2
//students names: pinchas rozenberg, ID: 206190258. yaakov gottlieb, ID: 318807583

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1
{
    class Program
    {
        static public void Print(int[] arr)
        {       //this function prints an array
            foreach (var i in arr)
            {
                Console.Write(i.ToString().PadLeft(4));
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] A = new int[20]; 
            int[] B = new int[20]; 
            int[] C = new int[20]; 

            for (int i = 0; i < A.Length; i++)
            {
                A[i] = rand.Next(18, 123);
                B[i] = rand.Next(18, 123);
            }

            for (int i = 0; i < C.Length; i++)
            {       //new array with tha gap between the first 2
                C[i] = Math.Abs(A[i] - B[i]);
            }

            Print(A);
            Print(B);
            Print(C);
        }
    }
}