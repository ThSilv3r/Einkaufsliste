using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary.Entity.Builder
{
    public interface IProductBuilder
    {
        void BuildProductName(string name);
        void BuildProductPrice(Price price);
        void BuildProductId(Guid guid);
        Product GetProduct();
    }
}
