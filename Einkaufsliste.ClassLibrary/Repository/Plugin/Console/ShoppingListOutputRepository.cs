﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Repository.Plugin.Console
{
    public interface ShoppingListOutputRepository
    {
        void foodsMessage();
        void productsMessage();
    }
}
