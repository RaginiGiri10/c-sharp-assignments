using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_Temperature
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter the current temperature(in celcius) : ");
                double currentTemperature = Convert.ToDouble(Console.ReadLine());
                Console.Write("Select an option: \n\n1)Convert into Celcius \n2)Convert into Fahrenheit \n3)Exit\n-->");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        double result1 = currentTemperature;
                        Console.WriteLine("The current temperature in celcius is : " + result1 + "'C");
                        break;
                    case 2:
                        double result2 = (currentTemperature * 9) / 5 + 32;
                        Console.WriteLine("The current temperature in fahrenheit is : " + result2 + "F");
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
