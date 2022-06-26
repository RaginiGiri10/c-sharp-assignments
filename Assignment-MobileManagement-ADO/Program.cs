using Assignment_MobileManagement_ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7_MobileManagement
{
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
                Console.WriteLine("\n*************Mobile Store*************\n"); Console.WriteLine();
                MobileRepository mobileRepository = new MobileRepository();
                List<Mobile> mobile = mobileRepository.GetAllMobileDetails();



                string n;
                do
                {
                    int userInput = OperationSelection();
                    switch (userInput)
                    {
                        case 1:
                            Mobile mobile1 = new Mobile { Name = "RealMe", Description = "Keypad", ManufacturedBy = "India", Price = 1500 };
                            MobileRepository mobileRepository1 = new MobileRepository();
                            mobileRepository1.AddMobile(mobile1);
                            break;
                        case 2:
                            foreach (Mobile mobiles in mobile)
                            {
                                Console.WriteLine($"Id -{mobiles.Id},Name -{mobiles.Name},Description -{mobiles.Description}, ManufacturedBy- {mobiles.ManufacturedBy},Price- {mobiles.Price}");
                            }

                            break;
                        case 3:

                            Mobile mobilelessThanMaxPrice = new Mobile();
                            MobileRepository mobileRepository5 = new MobileRepository();
                            mobileRepository5.SearchMobileWhosePriceLessThanMaxPrice(mobilelessThanMaxPrice);
                      
                            break;
                        case 4:
                            Mobile mobileManufacturedBy = new Mobile { ManufacturedBy = "India" };
                            MobileRepository mobileRepository2 = new MobileRepository();
                            mobileRepository2.SearchByManufacturer(mobileManufacturedBy);

                            break;
                        case 5:

                            MobileRepository mobileRepository3 = new MobileRepository();
                            mobileRepository3.viewAllMobilesWhosePriceIsGreaterThanMinumumMobilePriceAndLessThanMaximumMobilePrice();
                            break;
                        case 6:
                            MobileRepository mobileRepository4 = new MobileRepository();
                            mobileRepository4.DeleteMobilesWhosePriceIsGreaterThanMinumumMobilePriceAndLessThanMaximumMobilePrice();
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
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

