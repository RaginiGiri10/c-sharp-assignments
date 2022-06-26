using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Odd_Even
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the target number");
            int targetNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter '1' to print Odd number or '2' to print Even number");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                for (int i = 1; i < targetNumber; i++)
                {
                    if (i % 2 != 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            if (choice == 2)
            {
                for (int i = 1; i < targetNumber; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
