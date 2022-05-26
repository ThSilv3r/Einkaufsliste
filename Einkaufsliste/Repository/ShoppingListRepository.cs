﻿using Einkaufsliste.Domaine.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository
{
    public interface ShoppingListRepository
    {
        ShoppingList createShoppingList(string name);
        ShoppingList addFood(ShoppingList list, Guid foodId);
        ShoppingList addProduct(ShoppingList list, Guid productId);
    }
}
