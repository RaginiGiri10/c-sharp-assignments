using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_CharacterOccurence
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Enter a string :");
                string inputString = Console.ReadLine();
                inputString = inputString.ToLower();
                while (inputString.Length > 0)
                {
                    Console.Write(inputString[0] + " = ");
                    int cal = 0;
                    for (int j = 0; j < inputString.Length; j++)
                    {
                        if (inputString[0] == inputString[j])
                        {
                            cal++;
                        }
                    }
                    Console.WriteLine(cal);
                    inputString = inputString.Replace(inputString[0].ToString(), string.Empty);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
