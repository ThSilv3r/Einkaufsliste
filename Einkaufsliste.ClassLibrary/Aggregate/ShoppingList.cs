using Einkaufsliste.Domaine.Aggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.Domaine.Aggregate
{
    public class ShoppingList : IShoppingList
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> Products { get; set; }
        public List<Guid> Foods { get; set; }
    }
}
