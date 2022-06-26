using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4_Calculator
{
    delegate int CalculatorDelegate(int firstNumber, int secondNumber);
    class Calculator
    {
        public static int sumofTwoNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber; ;
        }
        public static int differenceOfTwoNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
        public static int multiplicationOfTwoNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }
        public static int divisionOfTwoNumbers(int firstNumber, int secondNumber)
        {
           return firstNumber / secondNumber;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int a;
                do
                {
                    Calculator calculator = new Calculator();
                    

                    int firstNumber, secondNumber;

                    float result1, result2, result3, result4;
                    int choice;

                    Console.WriteLine("CALCULATOR PROGRAM");
                    Console.WriteLine("Select one option: ");
                    Console.WriteLine("1. Addition (+)");
                    Console.WriteLine("2. Subtraction (-)");
                    Console.WriteLine("3. Multiplication (*)");
                    Console.WriteLine("4. Division (/)");
                    Console.WriteLine("5. Perform all operations:");
                    Console.WriteLine("6. Invalid choice");

                    Console.WriteLine("\nEnter your first number:- ");
                    firstNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter your second number:- ");
                    secondNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nEnter your choice:- ");

                    choice = Convert.ToInt32(Console.ReadLine());


                    switch (choice)
                    {
                        case 1:

                            Console.WriteLine($"Sum of {firstNumber} and {secondNumber} is {sumOfTwoNumbers(firstNumber, secondNumber)}");
                            break;
                        case 2:

                            Console.WriteLine($"Difference of {firstNumber} and {secondNumber} is {differenceOfTwoNumbers(firstNumber, secondNumber)}");
                            break;
                        case 3:

                            Console.WriteLine($"Multiplication of {firstNumber} and {secondNumber} is {multiplicationOfTwoNumbers(firstNumber, secondNumber)}");
                            break;
                        case 4:

                            Console.WriteLine($"Division of {firstNumber} and {secondNumber} is {divisionOfTwoNumbers(firstNumber, secondNumber)}");
                            break;
                        case 5:

                            CalculatorDelegate calculatorDelegate = new CalculatorDelegate(calculator.sumOfTwoNumbers);
                            calculatorDelegate += new CalculatorDelegate(calculator.differenceOfTwoNumbers);
                            calculatorDelegate += new CalculatorDelegate(calculator.multiplicationOfTwoNumbers);
                            calculatorDelegate += new CalculatorDelegate(calculator.divisionOfTwoNumbers);
                            calculatorDelegate(firstNumber, secondNumber);
                            break;
                        default:
                            Console.WriteLine("Invalid Choice\n");
                            break;
                            

                    }
                    Console.WriteLine("Press 1 to continue");
                    
                    a = Convert.ToInt32(Console.ReadLine());
                }


                while (a == 1);

                Console.ReadLine();
            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}



