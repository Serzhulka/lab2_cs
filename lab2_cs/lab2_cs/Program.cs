﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_cs
{
    class Program
    {
        // function to perform  
        // adding in the accumulator 
        static void add(int[] ac,
                        int[] x,
                        int qrn)
        {
            int i, c = 0;

            for (i = 0; i < qrn; i++)
            {

                // updating accumulator 
                // with A = A + BR 
                ac[i] = ac[i] + x[i] + c;

                if (ac[i] > 1)
                {
                    ac[i] = ac[i] % 2;
                    c = 1;
                }
                else
                    c = 0;
            }
        }

        // function to find  
        // the number's complement 
        static void complement(int[] a, int n)
        {
            int i;
            int[] x = new int[8];
            Array.Clear(x, 0, 8);

            x[0] = 1;

            for (i = 0; i < n; i++)
            {
                a[i] = (a[i] + 1) % 2;
            }
            add(a, x, n);
        }

        // function to perform  
        // right shift 
        static void rightShift(int[] ac, int[] qr,
                               ref int qn, int qrn)
        {
            int temp, i;
            temp = ac[0];
            qn = qr[0];

            Console.Write("\t\trightShift\t");

            for (i = 0; i < qrn - 1; i++)
            {
                ac[i] = ac[i + 1];
                qr[i] = qr[i + 1];
            }
            qr[qrn - 1] = temp;
        }

        // function to display  
        // operations 
        static void display(int[] ac,
                            int[] qr,
                            int qrn)
        {
            int i;

            // accumulator content 
            for (i = qrn - 1; i >= 0; i--)
                Console.Write(ac[i]);
            Console.Write("\t");

            // multiplier content 
            for (i = qrn - 1; i >= 0; i--)
                Console.Write(qr[i]);
        }

        // Function to implement 
        // booth's algo 
        static void boothAlgorithm(int[] br, int[] qr,
                                   int[] mt, int qrn,
                                   int sc)
        {

            int qn = 0;
            int[] ac = new int[10];
            Array.Clear(ac, 0, 10);

            int temp = 0;
            Console.Write("qn\tq[n + 1]\tBR\t" +
                           "\tAC\tQR\t\tsc\n");
            Console.Write("\t\t\tInitial\t\t");

            display(ac, qr, qrn);
            Console.Write("\t\t" + sc + "\n");

            while (sc != 0)
            {
                Console.Write(qr[0] + "\t" + qn);

                // SECOND CONDITION 
                if ((qn + qr[0]) == 1)
                {
                    if (temp == 0)
                    {

                        // subtract BR  
                        // from accumulator 
                        add(ac, mt, qrn);
                        Console.Write("\t\tA = A - BR\t");

                        for (int i = qrn - 1; i >= 0; i--)
                            Console.Write(ac[i]);
                        temp = 1;
                    }

                    // THIRD CONDITION 
                    else if (temp == 1)
                    {
                        // add BR to accumulator 
                        add(ac, br, qrn);
                        Console.Write("\t\tA = A + BR\t");

                        for (int i = qrn - 1; i >= 0; i--)
                            Console.Write(ac[i]);
                        temp = 0;
                    }
                    Console.Write("\n\t");
                    rightShift(ac, qr, ref qn, qrn);
                }

                // FIRST CONDITION 
                else if (qn - qr[0] == 0)
                    rightShift(ac, qr,
                               ref qn, qrn);

                display(ac, qr, qrn);

                Console.Write("\t");

                // decrement counter 
                sc--;
                Console.Write("\t" + sc + "\n");
            }
        }

        // Driver code 
        static void Main()
        {

            int[] mt = new int[10];
            int sc, brn, qrn;

            // Number of  
            // multiplicand bit 
            brn = 4;

            // multiplicand 
            int[] br = new int[] { 0, 1, 1, 0 };

            // copy multiplier  
            // to temp array mt[] 
            for (int i = brn - 1; i >= 0; i--)
                mt[i] = br[i];

            Array.Reverse(br);

            complement(mt, brn);

            // No. of  
            // multiplier bit 
            qrn = 4;

            // sequence  
            // counter 
            sc = qrn;

            // multiplier
            int[] qr = new int[] { 0, 0, 1, 0 };
            Array.Reverse(qr);

            boothAlgorithm(br, qr,
                           mt, qrn, sc);

            Console.WriteLine();
            Console.Write("Result = ");

            for (int i = qrn - 1; i >= 0; i--)
                Console.Write(qr[i]);
        }
    }
}