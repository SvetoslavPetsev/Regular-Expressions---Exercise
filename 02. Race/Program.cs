using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace _02._Race
{
    class Program
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split(", ");
            Regex patternNames = new Regex(@"[A-Za-z]");
            Regex patternNumbers = new Regex(@"[0-9]");
            Dictionary<string, int> race = new Dictionary<string, int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of race")
                {
                    break;
                }

                var name = patternNames.Matches(input);
                var time = patternNumbers.Matches(input);

                StringBuilder currName = new StringBuilder();
                foreach (Match letter in name)
                {
                    currName.Append(letter.Value);
                }
                string thisName = currName.ToString();
                int currTme = 0;
                foreach (Match digit in time)
                {
                    currTme += int.Parse(digit.Value);
                }
               
                if (names.Contains(thisName))
                {
                    if (!race.ContainsKey(thisName))
                    {
                        race.Add(thisName, currTme);
                    }
                    else
                    {
                        race[thisName] += currTme;
                    }
                }
            }

            List<string> orderedPlayers = new List<string>();
            foreach (var person in race.OrderByDescending(x => x.Value))
            {
                orderedPlayers.Add(person.Key);
            }
            Console.WriteLine($"1st place: {orderedPlayers[0]}");
            Console.WriteLine($"2nd place: {orderedPlayers[1]}");
            Console.WriteLine($"3rd place: {orderedPlayers[2]}");
        }
    }
}
