using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sess2.Models.Data;

namespace Sess2.Controllers
{
    public class ProductsController : Controller
    {
       // ProductRepository productRepository = new ProductRepository();

        Sess2.Models.NorthwindProductRespository northwindProductRespository = new Sess2.Models.NorthwindProductRespository();
       
        //get products by name
        public IActionResult GetProductsByName(string Name)
        {
            return Json(northwindProductRespository.GetProductsByName(Name));
        }

        public IActionResult Index(string name)
        {
            //var products = productRepository.GetProducts();

            if (string.IsNullOrEmpty(name))
            {
                var products = northwindProductRespository.GetProducts();
                return View(products);
            }

            else
            {
                var products = northwindProductRespository.GetProductsByName(name);
                return View(products);
            }
          
        }


        //add product
        public IActionResult AddProduct()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            northwindProductRespository.AddProduct(product);
            //return View(product);
            return RedirectToAction("Index");
        }

        //update product by id display the page 
        [Route(template: "/UpdateProduct/id")]
        public IActionResult UpdateProduct(int id)
        {
            var product = northwindProductRespository.GetProductById(id);
            if (product!=null)
            {
                return View(product);
            }
            else
            {
                TempData["Message"] = "Product No Found";
                return RedirectToAction("Index");
            }
        }

        //attribute based routing
        [Route(template: "/UpdateProduct/id")]
        [HttpPost]
        public IActionResult UpdateProduct(Sess2.Models.Data.Product product)
        {
            northwindProductRespository.UpdateProduct(product);
            TempData["Message"] = "Product updated";
            return RedirectToAction("Index");
        }



        //delete product
        //attribute based routing

        [Route(template: "/DeleteProduct/ ")]
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = northwindProductRespository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                TempData["Message"] = "Product No Found";
                return RedirectToAction("Index");
            }
        }


        [Route(template: "/DeleteProduct/")]
        [HttpPost,ActionName("DeleteProduct")]
        public IActionResult DeleteProduct()
        {

            short id = short.Parse(Request.Headers["referer"].ToString().Split("=")[1]);
            northwindProductRespository.DeleteProduct(id);
            TempData["Message"] = "product removed";
            return RedirectToAction("Index");
          
        }

      
    } 
}
