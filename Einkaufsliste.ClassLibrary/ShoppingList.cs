using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public List<Food> Foods { get; set; }
    }
}
