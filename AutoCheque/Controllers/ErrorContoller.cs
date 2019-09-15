using Microsoft.AspNetCore.Mvc;
using AutoCheque.Models;

namespace AutoCheque.Controllers
{
    public class ErrorController : ControllerBase
    {
        public ActionResult<string> PageNotFound()
        {
            var cheque = new ChequeModel(error: Constants.Errors.NotFoundError);
            return this.NotFound(cheque); 
        }
    }
}
