using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
{
    public class Food
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        public int Weight { get; set; }
        public Food(string name, Price price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
        public Food() { }
    }
}
