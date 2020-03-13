using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _01._Furniture
{
    class Program
    {
        static void Main()
        {
            Regex pattern = new Regex(@">>(?<item>[A-Z][A-Za-z]+)<<(?<cost>(\d+\.\d+)|(\d+))!(?<quantyty>\d+)");

            double sum = 0;
            string text = Console.ReadLine();

            List<string> boughtFurn = new List<string>();

            while (true)
            {
                if (text == "Purchase")
                {
                    break;
                }
                var furnitures = pattern.Matches(text);
                foreach (Match item in furnitures)
                {
                    string name = item.Groups["item"].Value;
                    boughtFurn.Add(name);
                    double price = double.Parse(item.Groups["cost"].Value);
                    int count = int.Parse(item.Groups["quantyty"].Value);
                    double currCost = price * (double)count;
                    sum += currCost;
                }
                text = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (string item in boughtFurn)
            {
                Console.WriteLine(item); ;
            }
            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}
