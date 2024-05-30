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

        public double CostSum()
        {
            return this.Products.Sum(product => product.Price);
        }

        public void AddProduct() 
        {
            Console.WriteLine();
            Console.WriteLine("Main>Add: Add products, 'exit' when done.");
            while (true) 
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("Product Category: ");
                string productCategory = Console.ReadLine().Trim();

                if (String.IsNullOrEmpty(productCategory)) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Product Category empty.");
                    continue;
                } 
                else if (productCategory == "exit")
                {
                    return;
                }

                Console.Write("Product Name: ");
                string productName = Console.ReadLine().Trim();
                double productPrice;

                if (String.IsNullOrEmpty(productName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Product Name empty.");
                    continue ;
                }
                else if (productName == "exit")
                {
                    return; 
                }

                try
                {
                    Console.Write("Product Price: ");
                    productPrice = Convert.ToDouble(Console.ReadLine());
                }
                catch 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Price needs to be a number.");
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Product added.");
                this.Products.Add(new Product(productPrice, productName, productCategory));
            }
        }

        public void SearchForProductName(string productName)
        {
            this.SortedProducts = Products.FindAll(product => product.Name.ToLower().Contains(productName.ToLower()));
            Console.WriteLine();

            if (this.SortedProducts.Count > 0)
            {
                Console.WriteLine($"Search results: {this.SortedProducts.Count}");
                Console.WriteLine("Category".PadRight(10) + "Name".PadRight(10) + "Price");
                Console.ForegroundColor= ConsoleColor.Cyan;
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

        public void ShowList()
        {
            Console.WriteLine();
            Console.WriteLine("Sorted list:");
            Console.WriteLine("Category".PadRight(10)+"Name".PadRight(10)+"Price");
            this.SortedProducts = this.Products.OrderBy(product => product.Price).ToList();

            foreach (var item in this.SortedProducts)
            {
                Console.WriteLine(item.Category.PadRight(10) + item.Name.PadRight(10) + item.Price);
            }
            Console.WriteLine("Total price:".PadRight(20) + this.SortedProducts.Sum(product => product.Price));
        }

    }
}
