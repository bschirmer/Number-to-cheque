using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoCheque.Models;


namespace AutoCheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "If you want me to work my magic, you have to give me a number value. e.g. api/cheque/782";
        }

        // GET api/values/5
        [HttpGet("{input}")]
        public ActionResult<string> Get(string input)
        {
            double n;
            if(!double.TryParse(input, out n))
            {
                return "Sorry friend, you need to enter a number";
            };

            if(n == 0)
            {
                return "Hold up, who wants a cheque for $0.00? Seems like a waste of paper. Try entering a number greater than 0";
            }  

            if(n < 0)
            {
                return "Sneaky, trying to get a cheque that pays you! Unfortunately, you need to enter a positive number";
            } 

            if (n > 100000000)
            {
                return "Over 100 million? That is too rich for this simple program. Maybe talk to your accountant for that one";
            }
            
            var cheque = new ChequeModel();
            return cheque.ConvertInputToNumberWords(n);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
