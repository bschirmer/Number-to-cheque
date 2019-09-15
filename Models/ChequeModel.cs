using System;

namespace AutoCheque.Models
{
    public class ChequeModel
    {
        public string Cheque {get; set;}
        public string Error {get; set;}
        public ChequeModel(string cheque = null, string error = null)
        {
            Cheque = cheque;
            Error = error;
        }
    }
}