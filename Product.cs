using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductListApp
{
    public class Product //The product class that makes the objects for list
    {
        public Product(double price, string name, string category)
        {
            this.Category = category;
            this.Name = name;
            this.Price = price;
        }

        public string Category 
        { get; }

        public string Name 
        { get; }

        public double Price 
        { get; }
    }
}
