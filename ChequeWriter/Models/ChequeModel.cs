using System.Reflection.Metadata;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ChequeWriter.Models
{
    // This class will have all the business logic for converting a double into a string
    public class ChequeModel
    {
        public string ConvertInputToNumberWords(double input)
        {
            var dollarString = string.Empty;
            var centString = string.Empty;
            // round number down to the nearest cent
            // NB: dropping rubbish decimals here will avoid weird rounding with string.format
            input = Math.Truncate(input * 100) / 100;

            // Process cents
            var c = Math.Round((input % 1)*100);
            if(c != 0)
            {
                centString = _convertLessThan1000(c);
                centString += " ";
                centString += (c == 1)? Constants.Cent : Constants.Cents;
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
                    dollarString = resultString + " " + Constants.BigGroups[groupNumber] + " " + dollarString;
                }
                   
                // Get ready for the next group.
                groupNumber++;
            }

            // Add a space for formatting
            dollarString += " ";

            dollarString += (Math.Truncate(input) == 1)? Constants.Dollar : dollarString = Constants.Dollars;

            return (centString == string.Empty)? dollarString : $"{dollarString} {Constants.And} {centString}";
        }

        private string _convertLessThan1000(double number)
        {
            // 0.01 % 1 * 100 = 1.000000000009, not 1
            var n = (int)number;
            var returnString = String.Empty;
            if(number > 99)
            {
                var hundred = (int)Math.Truncate(number / 100);
                returnString += $"{Constants.OneToNineteen[hundred]} {Constants.Tens[100]} ";

                n = n - (hundred * 100);

                if(n > 0) returnString += Constants.And + " ";
            }

            if(n >= 20)
            {
                var tens = (n/10)*10;
                var ones = n % 10;
                returnString += $"{Constants.Tens[tens]} {Constants.OneToNineteen[ones]}";
            } else 
            {
                returnString += Constants.OneToNineteen[n];
            }        

            return returnString;
        }
    }
}