using System.Collections.Generic;
public static class Constants 
{
    #region Terminology
    public const string Dollar = "DOLLAR";
    public const string Dollars = "DOLLARS";
    public const string Cent = "CENT";
    public const string Cents = "CENTS";
    public const string And = "AND";
    public const string Only = "ONLY";

    #endregion

    #region Numbers
    public static Dictionary<int, string> OneToNineteen = new Dictionary<int, string> {
            {0, ""},
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
            {18, "EIGHTEEN"},
            {19, "NINETEEN"}
        };

        public static Dictionary<int, string> Tens = new Dictionary<int, string> {
            {0, ""},
            {20, "TWENTY"},
            {30, "THIRTY"},
            {40, "FOURTY"},
            {50, "FIFTY"},
            {60, "SIXTY"},
            {70, "SEVENTY"},
            {80, "EIGHTY"},
            {90, "NINETY"},
            {100, "HUNDRED"}
        };

        public static List<string> BigGroups = new List<string> {
            "", "THOUSAND", "MILLION", "BILLION", "TRILLION"
        };
    #endregion

    #region Errors

    public static class Errors
    {
        public const string NotFoundError = "The route you have entered is not valid. Try https://localhost:5001/cheque";
        
        public const string NoInputError = "If you want me to work my magic, you have to give me a number value. e.g. https://localhost:5001/cheque/782";
        public const string NumberInputError = "Sorry friend, you need to enter a number";

        public const string ZeroInputError = "Hold up, who wants a cheque for $0.00? Seems like a waste of paper. Try entering a number greater than 0";

        public const string NegitiveNumberError = "Sneaky, trying to get a cheque that pays you! Unfortunately, you need to enter a positive number";
        public const string Over999TrillionError = "Over 999 trillion? That is too rich for this simple program. Maybe talk to your accountant for that one";
    }
    


    #endregion
}