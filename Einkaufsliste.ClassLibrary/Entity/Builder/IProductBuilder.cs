using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    internal interface IProductBuilder
    {
        void BuildName(string name);
        void BuildPrice(Price price);
        void BuildId(Guid guid);
        Product GetProduct();
    }
}
