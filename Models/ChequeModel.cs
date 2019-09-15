using System;

namespace AutoCheque.Models
{
    // This class will have all the business logic for converting a double into a string
    public class ChequeModel
    {
        public string Cheque {get; set;}
        public string Error {get; set;}
        public ChequeModel(string cheque = null, string error = null)
        {
            Cheque = cheque;
            Error = error;
        }
        public string ConvertInputToNumberWords(double input)
        {
            var dollarString = string.Empty;
            var centString = string.Empty;
            // round number down to the nearest cent
            // Math.x doesnt play nice with doubles. When Math.Truncate is used for some reason it rounds wrong.
            // e.g. 47.03 * 100 = 4702.99999998
            input = (double)Decimal.Truncate((decimal)input * 100) / 100;

            // Process cents
            var c = Math.Round((input % 1)*100);
            if(c != 0)
            {
                centString = _convertLessThan1000(c);
                centString += " ";
                centString += (c == 1)? Constants.Cent + " " + Constants.Only : Constants.Cents;
            }

            // Process dollars
            var d = Math.Truncate(input);
            if(d == 0) return centString;
            var groupNumber = 0;
            while(d > 0)
            {
                // Get the next group of three digits.
                double quotient = Math.Truncate(d / 1000);
                var remainder = Math.Round(d - (quotient * 1000));
                d = quotient;

                // Convert the group into words.
                if (remainder != 0)
                {
                    var resultString = _convertLessThan1000(remainder);

                    // This is to account for 1,0xx or ONE THOUSAND AND TWELVE DOLLARS
                    if(groupNumber == 0 && remainder < 100 && d != 0)
                    {
                        dollarString += Constants.And + " " + resultString + " " + dollarString;
                    } else if (groupNumber == 0)
                    {
                        dollarString += resultString + " " + dollarString;
                    } else
                    {
                        dollarString = resultString + " " + Constants.BigGroups[groupNumber] + " " + dollarString;
                    }
                    
                }
                   
                // Get ready for the next group.
                groupNumber++;
            }

            // Add dollar label
            dollarString += (Math.Truncate(input) == 1)? Constants.Dollar : dollarString = Constants.Dollars;

            return (centString == string.Empty)? dollarString : $"{dollarString} {Constants.And} {centString}";
        }

        private string _convertLessThan1000(double number)
        {
            var n = (int)number;
            var returnString = String.Empty;

            // Deal with hundred
            if(number > 99)
            {
                var hundred = (int)Math.Truncate(number / 100);
                returnString += $"{Constants.OneToNineteen[hundred]} {Constants.Tens[100]} ";

                n = n - (hundred * 100);

                if(n > 0) returnString += Constants.And + " ";
            }

            // deal with ty's
            if(n >= 20)
            {
                var tens = (n/10)*10;
                var ones = n % 10;
                returnString += $"{Constants.Tens[tens]} {Constants.OneToNineteen[ones]}";
            } else // deel with teens 
            {
                returnString += Constants.OneToNineteen[n];
            }        

            return returnString;
        }
    }
}