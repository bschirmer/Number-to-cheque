using Microsoft.AspNetCore.Mvc;
using AutoCheque.Models;

namespace AutoCheque.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChequeController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            var cheque = new ChequeModel(error: Constants.Errors.NoInputError);
            return new JsonResult(cheque); 
        }

        // GET api/values/5
        [HttpGet("{input}")]
        public ActionResult<string> Get(string input)
        {
            var cheque = new ChequeModel();
            double n;
            if(!double.TryParse(input, out n))
            {
                cheque.Error = Constants.Errors.NumberInputError;
                return new JsonResult(cheque);
            };

            if(n == 0)
            {
                cheque.Error = Constants.Errors.ZeroInputError;
                return new JsonResult(cheque);
            }  

            if(n < 0)
            {
                cheque.Error = Constants.Errors.NegitiveNumberError;
                return new JsonResult(cheque);
            } 

            if (n > 9999999999999)
            {
                cheque.Error = Constants.Errors.Over999TrillionError;
                return new JsonResult(cheque);
            }
            
            
            cheque.Cheque = ChequeConverter.ConvertInputToNumberWords(n);
            return new JsonResult(cheque);
        }
    }
}
