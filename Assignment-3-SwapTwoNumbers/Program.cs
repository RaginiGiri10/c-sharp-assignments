using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_SwapTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = 5;
                int b = 10;
                Console.WriteLine("Value of a is :" + a);
                Console.WriteLine("Value of b is :" + b);
                a = a + b;
                b = a - b;
                a = a - b;
                Console.WriteLine("Vale of a after swapping is :" + a);
                Console.WriteLine("Vale of b after swapping is :" + b);

                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
