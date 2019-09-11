using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace automatic_cheque_writer.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ChequeController : ControllerBase
    {
        // GET cheque/5
        [HttpGet("{number}")]
        public ActionResult<string> Get(int number)
        {
            // check for bad input
            
        

            // get the number as a string and return
            return "value: " + number;
        }

        // POST cheque
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        private static bool checkForBadInput(){
            return true;
        }
        private static Dictionary<int, string> numberString = new Dictionary<int, string>() {
            {1, "ONE"},
            {2, "TWO"},
            {3, "THREE"},
            {4, "FOUR"},
            {5, "FIVE"},
            {6, "SIX"},
            {7, "SEVEN"},
            {8, "EIGHT"},
            {9, "NINE"},
            {10, "TEN"},
            {11, "ELEVEN"},
            {12, "TWELVE"},
            {13, "THIRTEEN"},
            {14, "FOURTEEN"},
            {15, "FIFTEEN"},
            {16, "SIXTEEN"},
            {17, "SEVENTEEN"},
            {18, "EIGHTTEEN"},
            {19, "NINETEEN"},
            {20, "TWENTY"},
            {30, "THIRTY"},
            {40, "FOURTY"},
            {50, "FIFTY"},
            {60, "SIXTY"},
            {70, "SEVENTY"},
            {80, "EIGHTY"},
            {90, "NINEY"},
            {100, "HUNDRED"},
            {1000, "THOUSAND"},
            {1000000, "MILLION"}
        };

        private string getNumberString(float number)
        {
            // reject any numbers that are not allowed
            var numberString = "";

            // first, round down to the nearest cent (and 2 decimal places)
             var roundedNumber = Math.Round(number, 2, MidpointRounding.AwayFromZero);

            // split by decimal for dollars and cents

            // Form cent words

            // form dollar words
            
            numberString = roundedNumber.ToString();

            return numberString;
        }
    }
}
