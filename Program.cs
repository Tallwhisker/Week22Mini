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

string input = "";

while (input != "quit")
{
    Console.ForegroundColor = ConsoleColor.White; //At start of every loop set text to white
    Console.WriteLine();
    Console.WriteLine("Commands: 'add' 'list' 'search' 'quit'");

    Console.Write("@ Main: ");
    input = Console.ReadLine().Trim().ToLower();

    switch (input)
    {
        case "add": //Go to AddProduct loop
            productList.AddProduct();
            break;

        case "list": //Print the list
            productList.ShowList();
            break;

        case "search": //Ask for search term and send to search method
            Console.WriteLine();
            Console.Write("Search for product name: ");
            string searchTerm = Console.ReadLine().Trim().ToLower();
            productList.SearchForProductName(searchTerm);
            break;

        case "quit":
            break;

        default: //If none of the above are recognized, tell user.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unknown input.");
            break;
    }
}

Console.ForegroundColor = ConsoleColor.White;
productList.ShowList();