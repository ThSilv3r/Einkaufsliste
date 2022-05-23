using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
{
    internal interface IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
