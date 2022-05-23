using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
{
    public class Food : IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }
        public Food(string name, double price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
        public Food() { }
    }
}
