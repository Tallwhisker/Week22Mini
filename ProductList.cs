using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductListApp
{
    public class ProductList
    {
        public ProductList()
        {
            this.Products = new List<Product>();
            this.SortedProducts = new List<Product>();
        }

        public List<Product> Products
        { get; set; }

        public List<Product> SortedProducts
        { get; set; }

        public void AddProduct() //Method loop for adding products and checking input
        {
            Console.WriteLine();
            Console.WriteLine("@ Main/Add: Add products, 'exit' when done.");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White; //Start each loop setting text to white
                Console.Write("Product Category: ");
                string productCategory = Console.ReadLine().Trim();

                if (String.IsNullOrEmpty(productCategory))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Product Category empty.");
                    continue;
                }
                else if (productCategory == "exit") //Provide an exit at question #1
                {
                    Console.WriteLine("Returning to Main.");
                    return;
                }

                Console.Write("Product Name: ");
                string productName = Console.ReadLine().Trim();
                double productPrice; //Needs to be outside its block for access

                if (String.IsNullOrEmpty(productName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Product Name empty. (A-z)");
                    continue;
                }
                else if (productName == "exit") //Provide an exit at question #2
                {
                    Console.WriteLine("Returning to Main.");
                    return;
                }

                try //Try to convert price input
                {
                    Console.Write("Product Price: ");
                    productPrice = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Incorrect Price value. (0-9)");
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green; //If no errors are triggered, add new product object to list
                Console.WriteLine("Product added.");
                this.Products.Add(new Product(productPrice, productName, productCategory));
                Console.WriteLine();
            }
        }

        public void SearchForProductName(string productName)
        {
            //Find all matches and return them to Sorted
            StringComparison strCompare = StringComparison.OrdinalIgnoreCase;
            this.SortedProducts = this.Products.FindAll(product => product.Name.Contains(productName, strCompare));
            Console.WriteLine();

            if (this.SortedProducts.Count > 0) //If there's any matches, run this
            {
                Console.WriteLine($"Search results: {this.SortedProducts.Count}");
                Console.WriteLine("Category".PadRight(10) + "Name".PadRight(10) + "Price");
                Console.ForegroundColor = ConsoleColor.Cyan;

                foreach (Product product in this.SortedProducts)
                {
                    Console.WriteLine(product.Category.PadRight(10) + product.Name.PadRight(10) + product.Price);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No matches found for {productName}");
            }
        }

        public void ShowList() //Prints category table and ascending Price-sorted list with sum at bottom
        {
            Console.WriteLine();
            Console.WriteLine("Sorted list:");
            Console.WriteLine("Category".PadRight(20) + "Name".PadRight(20) + "Price");
            this.SortedProducts = this.Products.OrderBy(product => product.Price).ToList();

            foreach (var item in this.SortedProducts)
            {
                Console.WriteLine(item.Category.PadRight(20) + item.Name.PadRight(20) + item.Price);
            }

            Console.WriteLine("Total price:".PadRight(40) + this.SortedProducts.Sum(product => product.Price));
        }
    }
}
