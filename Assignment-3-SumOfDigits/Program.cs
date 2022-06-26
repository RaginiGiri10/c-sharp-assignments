using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_SumOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the total number you want to add :");
                int numberLength = Convert.ToInt32(Console.ReadLine());
                List<int> numbers = new List<int>();
                int userInput;
                for (int i = 0; i < numberLength; i++)
                {
                    Console.WriteLine("Number" + (i + 1));
                    userInput = Convert.ToInt32(Console.ReadLine());
                    numbers.Add(userInput);

                }
                Console.WriteLine("Sum of the numbers are:" + numbers.Sum());

                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
