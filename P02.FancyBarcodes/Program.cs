using System.Globalization;
using System.Text.RegularExpressions;

namespace P02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int barcodesCount = int.Parse(Console.ReadLine());
            string pattern = @"@{1}#+[A-Z][A-Za-z0-9]{4,}[A-Z]@{1}#+";

            for (int i = 0; i < barcodesCount; i++)
            {
                string input = Console.ReadLine();

                if (!Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
                else
                {
                    char[] charsArray = input.ToCharArray();
                    char[] digitsArray = charsArray.Where(char.IsDigit).ToArray();
                    if (digitsArray.Length == 0)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        string result = new string(digitsArray);
                        Console.WriteLine($"Product group: {result}");
                    }
                }
            }
        }
    }
}