using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Interfaces
{
    public interface IShoppingList
    {
        Guid Id { get; set; }
        string Name { get; set; }
        List<Product> Products { get; set; }
        List<Food> Foods { get; set; }
    }
}
