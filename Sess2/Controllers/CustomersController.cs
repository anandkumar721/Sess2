using Microsoft.AspNetCore.Mvc;
using Sess2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sess2.Controllers
{
    public class CustomersController : Controller
    {
        NorthwindProductRespository northwindProductRespository = new NorthwindProductRespository();

        public IActionResult Index()
        {
            var customers = northwindProductRespository.GetCustomers();
            return View(customers);
           
        }
    }
}
