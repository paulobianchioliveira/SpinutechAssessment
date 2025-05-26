using System.Text;

namespace SpinutechAssessment
{
    public class Utils
    {
        private static string[] units = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                                      "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                                      "Seventeen", "Eighteen", "Nineteen" };

        private static string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public static string NumberToWords(decimal number)
        {
            if (number == 0)
                return "Zero";

            long intPart = (long)Math.Floor(number);
            int decimalPart = (int)((number - intPart) * 100);

            StringBuilder words = new StringBuilder();

            words.Append(NumberToWords(intPart));

            if (decimalPart > 0)
            {
                if (words.Length > 0)
                    words.Append(" and ");

                words.Append($"{decimalPart}/100");
                //words.Append(decimalPart == 1 ? " Cent" : " Cents");
            }

            words.Append(" Dollars");

            return words.ToString();
        }

        private static string NumberToWords(long number)
        {
            if (number == 0)
                return "";

            if (number < 20)
                return units[number];

            if (number < 100)
                return tens[number / 10] + (number % 10 > 0 ? "-" + units[number % 10] : "");

            if (number < 1000)
                return units[number / 100] + " Hundred" + (number % 100 > 0 ? " " + NumberToWords(number % 100) : "");

            if (number < 1000000)
                return NumberToWords(number / 1000) + " Thousand" + (number % 1000 > 0 ? " " + NumberToWords(number % 1000) : "");

            if (number < 1000000000)
                return NumberToWords(number / 1000000) + " Million" + (number % 1000000 > 0 ? " " + NumberToWords(number % 1000000) : "");

            return NumberToWords(number / 1000000000) + " Billion" + (number % 1000000000 > 0 ? " " + NumberToWords(number % 1000000000) : "");
        }
    }
}
