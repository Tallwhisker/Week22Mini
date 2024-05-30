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


while (true)
{
    Console.ForegroundColor = ConsoleColor.White; //At start of every loop set text to white
    Console.WriteLine();
    Console.WriteLine("Commands: 'add' 'list' 'search' 'quit'");

    Console.Write("@ Main: ");
    string input = Console.ReadLine().Trim().ToLower();

    if (input == "quit") //Show list and stop main loop
    {
        productList.ShowList();
        break;
    }
    else if (input == "add") //Go to AddProduct loop
    {
        productList.AddProduct();
    }
    else if (input == "list") //Print the list
    {
        productList.ShowList();
    }
    else if (input == "search") //Ask for search term and send to search method
    {
        Console.WriteLine();
        Console.Write("Search for product name: ");
        string searchTerm = Console.ReadLine().Trim().ToLower();
        productList.SearchForProductName(searchTerm);
    }
    else //If none of the above are recognized, go back to input
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Unknown input.");
        continue;
    }
}