using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//adding namespace
using Sess2.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Sess2.Models
{
    
    public class NorthwindProductRespository // :IProductRepository
    {
        NorthwindDbContext.NorthwindContext context = new NorthwindDbContext.NorthwindContext();

        //get all products
        public IEnumerable<Sess2.Models.Data.Product> GetProducts()
        {
            return context.Products.ToList();
        }

        //search product by name
        public IEnumerable<Sess2.Models.Data.Product> GetProductsByName(string name)
        {
            return context.Products.Where(Product => Product.Productname.Contains(name)).ToList();
        }

        //add customer -model.data
        public IEnumerable<Sess2.Models.Data.Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        //adding product-AddProducts.cshtml
        public void AddProduct(Data.Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        //Update product
        public void UpdateProduct(Data.Product product)
        {
            context.Entry<Data.Product>(product).State = EntityState.Modified;
            context.SaveChanges();
        }


        //delete product 
        public void DeleteProduct(short id)
        {
            var prod = context.Find<Data.Product>(id);
            context.Entry<Data.Product>(prod).State = EntityState.Deleted;
            context.SaveChanges();
            //context.Entry<Data.Product>(product).State = EntityState.Deleted;
            //context.SaveChanges();
        }


        //get product by id
        public Data.Product GetProductById(int id)
        {
            return context.Products.Where(Product => Product.Productid == id).FirstOrDefault();
        }
    }
}
