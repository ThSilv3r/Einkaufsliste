using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Interfaces
{
    public interface IProduct
    {
        string Name { get; set; }
        Price Price { get; set; }
    }
}
