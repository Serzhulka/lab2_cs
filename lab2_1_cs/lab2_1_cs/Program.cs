using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUDemonstration
{
    class Program
    {
        //Writing in binary function overloads
        static public string WriteInBinary(long n)
        {            
            string result = Convert.ToString(n, 2);
            return result;
        }
        static public string WriteInBinary(uint n)
        {            
            string result = Convert.ToString(n, 2);
            return result;
        }
        static public string WriteInBinary(ulong n)
        {
            
            string result = Convert.ToString((long)n, 2);
            return result;
        }
        static public string WriteInBinary(int n)
        {
            
            string result = Convert.ToString(n, 2);
            return result;
        }

        

        //2. ALU Division, from as-is to remainder and quotient in one register method.
        static public void DivideAsIs()
        {
            //divident / divisor = quotient( + remainder)
            //divident - divisor
            long divisor = 2;
            divisor = divisor << 32;
            long remainder = 7; //remainder is divident in the beginning
            int quotient = 0;

            for (int i = 0; i < 32 + 1; i++)
            {
                remainder = remainder - divisor;
                if (remainder >= 0)
                {
                    quotient = quotient << 1;
                    Console.WriteLine("1 q\n{0}\n->", WriteInBinary(quotient));
                    quotient = quotient | 1;
                    Console.WriteLine("q\n{0}", WriteInBinary(quotient));
                }
                else
                {
                    remainder += divisor;
                    quotient = quotient << 1;
                    Console.WriteLine("2 q\n{0}\n->", WriteInBinary(quotient));
                    quotient = quotient & ((int)-2);
                    Console.WriteLine("q\n{0}", WriteInBinary(quotient));
                }
                divisor = divisor >> 1;
            }
            Console.WriteLine("remainder\n{0}\n{1}", WriteInBinary(remainder), remainder);
            Console.WriteLine("quotient\n{0}\n{1}", WriteInBinary(quotient), quotient);
        }
        static public void Dividevariant2()
        {
            Console.WriteLine("{0}\n{1}\n{2}", WriteInBinary((long)(Math.Pow(2, 32) - 1)), (Math.Pow(2, 32) - 1), (long)(Math.Pow(2, 32) - 1));

            int divisor = 33;
            long remainder = 100; //remainder contains  divident in the beginning
            int quotient = 0;

            for (int i = 0; i < 32; i++)
            {
                remainder = remainder << 1;
                Console.WriteLine("this is remainder {0} :: {1}", WriteInBinary(remainder), remainder);
                remainder = ((remainder - ((long)divisor << 32)) & (-4294967296)) + (remainder & (long)4294967295);
                Console.WriteLine("this is remainder - divisor {0} :: {1}", WriteInBinary(remainder), remainder);


                if (remainder >= 0)
                {
                    quotient = quotient << 1;
                    Console.WriteLine("1 q\n{0}\n->", WriteInBinary(quotient));
                    quotient = quotient | 1;
                    Console.WriteLine("q\n{0}", WriteInBinary(quotient));
                }
                else
                {
                    remainder += (long)divisor << 32;
                    quotient = quotient << 1;
                    Console.WriteLine("2 q\n{0}\n->", WriteInBinary(quotient));
                    quotient = quotient & ((int)-2);
                    Console.WriteLine("q\n{0}", WriteInBinary(quotient));
                }

                Console.WriteLine("this is remainder {0} :: {1}", WriteInBinary(remainder), remainder);
            }

            Console.WriteLine("remainder\n{0}\n{1}", WriteInBinary(remainder >> 32), remainder >> 32);
            Console.WriteLine("quotient\n{0}\n{1}", WriteInBinary(quotient), quotient);
        }
        static public void Dividevariant3()
        {
            //Console.WriteLine("{0}\n{1}\n{2}", WriteInBinary((long)(Math.Pow(2, 32) - 1)), (Math.Pow(2, 32) - 1), (long)(Math.Pow(2, 32) - 1));

            int divisor = 25;
            long remainder_quotient = 100;

            try
            {
                Console.WriteLine("Enter your divident: ");
                remainder_quotient = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your divisor: ");
                divisor = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("nope, not this numbers. buy.");
                return;
            }

            Console.WriteLine("Press any key to coninue.");
            Console.ReadKey();

            remainder_quotient = remainder_quotient << 1;
            for (int i = 0; i < 32; i++)
            {
                remainder_quotient = remainder_quotient << 1;
                Console.WriteLine("this is remainder {0} :: {1}", WriteInBinary(remainder_quotient), remainder_quotient);
                remainder_quotient = ((remainder_quotient - ((long)divisor << 32)) & (-4294967296)) + (remainder_quotient & (long)4294967295);
                Console.WriteLine("this is remainder - divisor {0} :: {1}", WriteInBinary(remainder_quotient), remainder_quotient);


                if (remainder_quotient >= 0)
                {
                    Console.WriteLine("1 q\n{0}\n->", WriteInBinary(remainder_quotient));
                    remainder_quotient = remainder_quotient | 1;
                    Console.WriteLine("q\n{0}", WriteInBinary(remainder_quotient));
                }
                else
                {
                    remainder_quotient = ((remainder_quotient + ((long)divisor << 32)) & (-4294967296)) + (remainder_quotient & (long)4294967295);
                    Console.WriteLine("2 q\n{0}\n->", WriteInBinary(remainder_quotient));
                    remainder_quotient = remainder_quotient & ((long)-2);
                    Console.WriteLine("q\n{0}", WriteInBinary(remainder_quotient));
                }

                Console.WriteLine("this is remainder {0} :: {1}", WriteInBinary(remainder_quotient), remainder_quotient);
            }

            remainder_quotient = remainder_quotient >> 1;

            Console.WriteLine("remainder_qoutient\n{0}\n{1}", WriteInBinary(remainder_quotient), remainder_quotient);
            Console.WriteLine("remainder\n{0}\n{1}", WriteInBinary(remainder_quotient >> 32), remainder_quotient >> 32);
            Console.WriteLine("quotient\n{0}\n{1}", WriteInBinary((remainder_quotient << 32) >> 32), (remainder_quotient << 32) >> 32);
        }        
        static void Main(string[] args)
        {
            //MultiplyAsIs();

            Dividevariant3();

            //TryingFlop3();
            //FlPtBintoDec(1);

            Console.ReadKey();
        }
    }
}
