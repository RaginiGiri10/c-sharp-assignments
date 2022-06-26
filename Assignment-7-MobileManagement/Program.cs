using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7_MobileManagement
{
    class JoMart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ManufacturedBy { get; set; }
        public double Price { get; set; }
        public static List<JoMart> JoMartList = new List<JoMart>();

        public static void AddMobileProduct()
        {
            try
            {
                var product = new JoMart();
                Console.Write("Enter mobile name :");
                product.Name = Console.ReadLine();
                foreach (var n in JoMartList)
                    if (n.Name == product.Name)
                    {
                        Console.WriteLine("Mobile name already exists");

                    }
                Console.Write("Enter description of the mobile :");
                product.Description = Console.ReadLine();
                Console.Write("Enter manufactured by  :");
                product.ManufacturedBy = Console.ReadLine();
                Console.Write("Enter the product's price  :");
                product.Price = Convert.ToDouble(Console.ReadLine());
                product.Id = JoMartList.Count == 0 ? 3000 : JoMartList.Max(x => x.Id) + 1;
                JoMartList.Add(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void ViewAllMobileDetails()
        {
            if (JoMartList.Count == 0)
                Console.WriteLine("No mobile details found.");
            else
            {
                Console.WriteLine("********************Mobile Details************************");
                foreach (var product in JoMartList)
                {
                    var productDetail = string.Format("ID : {0} Name : {1} Description : {2} ManufacturedBy : {3} Price : {4}", product.Id, product.Name, product.Description, product.ManufacturedBy, product.Price);
                    Console.WriteLine(productDetail);
                }
            }
        }
        public static void ViewAllMobileLessThanMaxPriceOfTheMobile()
        {

            if (JoMartList.Count == 0)
                Console.WriteLine("No mobile details found.");
            else
            {
                foreach (var product in JoMartList)
                {
                    if (product.Price < JoMartList.Max(x => x.Price))
                    {
                        var MobileDetailLessThanMaxPrice = string.Format("ID : {0} Name : {1} Description : {2} ManufacturedBy : {3} Price : {4}", product.Id, product.Name, product.Description, product.ManufacturedBy, product.Price);
                        Console.WriteLine(MobileDetailLessThanMaxPrice);
                    }
                }
            }

        }
        public static void ViewAllMobileByManufacturer()
        {
            try
            {
                if (JoMartList.Count == 0)

                    Console.WriteLine("No detail found");

                else
                {
                    Console.Write("Enter Manufacturer name :");

                    string searchManufacturer = Console.ReadLine();
                    foreach (var product in JoMartList)
                    {
                        if (searchManufacturer == product.ManufacturedBy)
                        {

                            var MobileDetailsManufacturedBy = string.Format("ID : {0} Name : {1} Description : {2} ManufacturedBy : {3} Price : {4}", product.Id, product.Name, product.Description, product.ManufacturedBy, product.Price);
                            Console.WriteLine(MobileDetailsManufacturedBy);

                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void ViewAllMobileWhosePriceGreaterThanMinimumMobilePriceAndLessThanMaximimMobilePrice()
        {
            if (JoMartList.Count == 0)
            {
                Console.WriteLine("No detail found");
            }
            else
            {
                var minimumPrice = JoMartList.Min(x => x.Price);
                var maximumPrice = JoMartList.Max(x => x.Price);
                foreach (var product in JoMartList)
                {
                    if (minimumPrice < product.Price && product.Price < maximumPrice)
                    {
                        Console.WriteLine($"Mobile Name={product.Name} Mobile Description={product.Description} Mobile Price={product.Price} Manufactured By={product.ManufacturedBy}");
                    }

                }

            }
        }
        public static void RemoveMobilesWhosePriceGreaterThanMinimumMobilePriceAndLessThanMaximimMobilePrice()
        {
            if (JoMartList.Count == 0)
            {
                Console.WriteLine("No detail found");

            }
            else
            {
                var minimumPrice = JoMartList.Min(x => x.Price);
                var maximumPrice = JoMartList.Max(x => x.Price);
                JoMartList.RemoveAll(x => x.Price > minimumPrice && x.Price < maximumPrice);
                Console.WriteLine("Mobile details whose price is greater than minimum mobile price and less than maximum mobile price has been removed successfully.");

            }

        }


        class Program
        {
            
            private static int OperationSelection()
            {
                Console.WriteLine("Press 1 to add mobile details. ");
                Console.WriteLine("Press 2 to view all mobiles available in the store. ");
                Console.WriteLine("Press 3 to search mobile whose price is less than the max price of the mobile. ");
                Console.WriteLine("Press 4 to search all mobiles by manufacturer. ");
                Console.WriteLine("Press 5 to view all mobiles whose price is greater than minimum mobile price and less than maximum mobile price.  ");
                Console.WriteLine("Press 6 to remove mobile whose price is greater than minimum mobile price and less than maximum mobile price. ");
                return Convert.ToInt32(Console.ReadLine());
            }
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("\n*************JoMart Retail Store*************\n"); Console.WriteLine();
                    string n;

                    do
                    {
                        int userInput = OperationSelection();
                        switch (userInput)
                        {
                            case 1:
                                JoMart.AddMobileProduct();
                                break;
                            case 2:
                                JoMart.ViewAllMobileDetails();
                                break;
                            case 3:
                                JoMart.ViewAllMobileLessThanMaxPriceOfTheMobile();
                                break;
                            case 4:
                                JoMart.ViewAllMobileByManufacturer();
                                break;
                            case 5:
                                JoMart.ViewAllMobileWhosePriceGreaterThanMinimumMobilePriceAndLessThanMaximimMobilePrice();
                                break;
                            case 6:
                                JoMart.RemoveMobilesWhosePriceGreaterThanMinimumMobilePriceAndLessThanMaximimMobilePrice();
                                break;
                            default:
                                Console.WriteLine("Invalid Option");
                                break;

                        }
                        Console.WriteLine();
                        Console.WriteLine("Press Y to continue");
                        n = Console.ReadLine();
                    }
                    while (n == "y" || n == "Y");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        
       

        }

    }
}
