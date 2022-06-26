using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6_ProductList
{
    class Flipko
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ManufacturedBy { get; set; }
        public double Price { get; set; }


    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("***PRODUCT MANAGEMENT***"); Console.WriteLine();
                string n;
                List<Flipko> FlipkoList = new List<Flipko>();
                do
                {
                    int userInput = OperationSelection();
                    switch (userInput)
                    {
                        case 1:
                            AddProduct(FlipkoList);
                            break;
                        case 2:
                            ViewAllProductDetails(FlipkoList);
                            break;
                        case 3:
                            ViewAllProductDetails(FlipkoList, true);
                            break;
                        case 4:
                            FlipkoList.Clear();
                            Console.WriteLine("Products's records deleted successfully!!!");
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
        private static int OperationSelection()
        {
            Console.WriteLine("Press 1 to add product details ");
            Console.WriteLine("Press 2 to view all product's details ");
            Console.WriteLine("Press 3 to view all product's details with price greater than 1000 ");
            Console.WriteLine("Press 4 to remove all product's details ");
            return Convert.ToInt32(Console.ReadLine());
        }
        private static void ViewAllProductDetails(List<Flipko> productList, bool checkPriceGreaterThanThousand = false)
        {
            if (productList.Count == 0)
                Console.WriteLine("No product details found.");
            else
            {
                Console.WriteLine("Product Details :");
                if (checkPriceGreaterThanThousand)
                    productList = productList.Where(x => x.Price > 1000).ToList();
                foreach (var product in productList)
                {
                    var productDetail = string.Format("ID : {0} Name : {1} Description : {2} ManufacturedBy : {3} Price : {4}", product.Id, product.Name, product.Description, product.ManufacturedBy,product.Price);
                   Console.WriteLine(productDetail);
                }
                foreach (var product in productList)
                {
                    var existingProduct = productList.Find(x => x.Name == product.Name && x.Description == product.Description);
                    if (existingProduct == null)
                    {
                        productList.Add(product);
                    }
                    else
                    {
                        Console.WriteLine($"Product{product.Name} already exists");
                    }
                }
            }
        }
        private static void AddProduct(List<Flipko> FlipkoList)
        {
            var product = new Flipko();
            Console.WriteLine("Enter product name :");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter description of the product :");
            product.Description =Console.ReadLine();
            Console.WriteLine("Enter manufactured by  :");
            product.ManufacturedBy =Console.ReadLine();
            Console.WriteLine("Enter the product's price  :");
            product.Price = Convert.ToDouble(Console.ReadLine());
            product.Id = FlipkoList.Count == 0 ? 1000 : FlipkoList.Max(x => x.Id) + 1;
            FlipkoList.Add(product);
        }
    }
}


