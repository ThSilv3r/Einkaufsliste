using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        public Product(string name, Price price)
        {
            Name = name;
            Price = price;
        }
        public Product() { }
    }
}
