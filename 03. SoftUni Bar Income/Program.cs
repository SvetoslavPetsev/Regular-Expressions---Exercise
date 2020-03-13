using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main()
        {
           Regex pattern = new Regex(@"^%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$");
            decimal totalIncome = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of shift")
                {
                    break;
                }

                var matches = pattern.Match(input);
                if (matches.Success)
                {
                    string name = matches.Groups["name"].Value;
                    string product = matches.Groups["product"].Value;
                    int quantity = int.Parse(matches.Groups["count"].Value);
                    decimal price = decimal.Parse(matches.Groups["price"].Value);

                    decimal totalPrice = quantity * price;
                    Console.WriteLine($"{name}: {product} - {totalPrice:F2}");
                    totalIncome += totalPrice;
                }
            }
            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
