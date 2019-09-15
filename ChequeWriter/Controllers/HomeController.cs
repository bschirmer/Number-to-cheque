using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChequeWriter.Models;
using System.Text.Encodings.Web;

namespace ChequeWriter.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string input)
        {
            double n;
            if(!double.TryParse(input, out n))
            {
                ViewData["error"]= "Sorry friend, you need to enter a number";
                return View();
            };

            if(n == 0)
            {
                ViewData["error"]= "Hold up, who wants a cheque for $0.00? Seems like a waste of paper. Try entering a number greater than 0";
                return View();
            }  

            if(n < 0)
            {
                ViewData["error"]= "Sneaky, trying to get a cheque that pays you! Unfortunately, you need to enter a positive number";
                return View();
            } 

            if (n > 100000000)
            {
                ViewData["error"]= "Over 100 million? That is too rich for this simple program. Maybe talk to your accountant for that one";
                return View();
            }
            
            var cheque = new ChequeModel();
            ViewData["input"] = n;
            ViewData["number"] = cheque.ConvertInputToNumberWords(n);

            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
