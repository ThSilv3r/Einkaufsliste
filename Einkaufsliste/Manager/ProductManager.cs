using Einkaufsliste.ClassLibrary;
using Einkaufsliste.ClassLibrary.Entity.Builder;
using Einkaufsliste.ClassLibrary.Repository;
using Einkaufsliste.ClassLibrary.ValueObject;
using System;
using System.Collections.Generic;

namespace Einkaufsliste
{
    public class ProductManager : IProductManager
    {
        public Product createProduct(string name, Price price)
        {
            double priceDouble;
            Product product = new Product();
            ProductBuilder productBuilder = new ProductBuilder();
            ProductEngineer productEngineer = new ProductEngineer(productBuilder);


            if(name != null && name != "")
            {
                productEngineer.constructProduct(name, price);
                product = productEngineer.GetProduct();
                return product;
            }
            return null;
        }

        public Product getProductById(Guid guid, List<Product> products)
        {
            Product product = products.Find(x => x.Id == guid);
            return product;
        }
    }
}
