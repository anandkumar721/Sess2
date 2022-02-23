using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sess2.Models
{
    public class ProductRepository : IProductRepository
    {

        List<Product> allProducts = new List<Product>();

        //public ProductRepository()
        //{
        //    allProducts.AddRange(new Product[]
        //    {
        //        new Product{Id=1,Name="abc",Price=300},
        //        new Product{Id=2,Name="xyz",Price=500},

        //    });
        //}

        //public IEnumerable<Product> GetProducts()
        //{
        //    return allProducts;
        //}
    }
}
