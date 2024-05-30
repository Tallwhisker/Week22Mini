using ProductListApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


ProductList productList = new ProductList();
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("-----------------");
Console.WriteLine(" Product Manager");
Console.WriteLine("-----------------");

//DEBUGstuff
productList.Products.Add(new Product(194, "name1", "cat1"));
productList.Products.Add(new Product(543, "name2", "cat2"));
productList.Products.Add(new Product(56734, "name3", "cat3"));
productList.Products.Add(new Product(23, "name4", "cat4"));

while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine();
    Console.WriteLine("Commands: 'add' 'list' 'search' 'quit'");

    Console.Write("Main: ");
    string input = Console.ReadLine().Trim().ToLower();


    if (input == "quit")
    {
        productList.ShowList();
        break;
    }
    else if (input == "add")
    {
        productList.AddProduct();
    }
    else if (input == "list")
    {
        productList.ShowList();
    }
    else if (input == "search")
    {
        Console.WriteLine();
        Console.Write("Search for product name: ");
        string searchTerm = Console.ReadLine().Trim().ToLower();
        productList.SearchForProductName(searchTerm);
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Unknown input.");
        continue;
    }
}