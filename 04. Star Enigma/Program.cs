using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Star_Enigma
{
    public class Planet
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public char TypeAttack { get; set; }
        public int SouldierCount { get; set; }

        public Planet(string name, int population, char attack, int soldierCount)
        {
            this.Name = name;
            this.Population = population;
            this.TypeAttack = attack;
            this.SouldierCount = soldierCount;
        }
    }
    class Program
    {
        static void Main()
        {
            List<Planet> planets = new List<Planet>();
            int numberMessages = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberMessages; i++)
            {
                string input = Console.ReadLine();
                string inputForDisricp = input.ToLower();
                char[] code = new char[] { 's', 't', 'a', 'r' };
                int symbolSum = 0;

                foreach (char symbol in inputForDisricp)
                {
                    for (int j = 0; j < code.Length; j++)
                    {
                        if (symbol == code[j])
                        {
                            symbolSum++;
                            continue;
                        }
                    }
                }
                StringBuilder decriptedMassage = new StringBuilder();

                for (int k = 0; k < input.Length; k++)
                {
                    char currSymbol = input[k];
                    currSymbol -= (char)symbolSum;
                    decriptedMassage.Append(currSymbol);
                }
                string text = decriptedMassage.ToString();
                Regex pattern = new Regex(@"\@(?<planetName>[a-zA-Z]+)[^@\-!:>]*\:(?<population>\d+)[^@\-!:>]*\!(?<type>[A|D])\![^@\-!:>]*\-\>(?<souldierCount>\d+)");
                var matches = pattern.Match(text);
                if (matches.Success)
                {
                    string planetName = matches.Groups["planetName"].Value;
                    int population = int.Parse(matches.Groups["population"].Value);
                    char attackType = char.Parse(matches.Groups["type"].Value);
                    int souldierCount = int.Parse(matches.Groups["souldierCount"].Value);
                    Planet newPlanet = new Planet(planetName, population, attackType, souldierCount);
                    planets.Add(newPlanet);
                }
            }
            int sumAttaked = planets.Count(x => x.TypeAttack == 'A');
            int sumDestryed = planets.Count(x => x.TypeAttack == 'D'); ;
            Console.WriteLine($"Attacked planets: {sumAttaked}");
            if (sumAttaked != 0)
            {
                foreach (Planet planet in planets.Where(x => x.TypeAttack == 'A').OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-> {planet.Name}");
                }
            }
            Console.WriteLine($"Destroyed planets: {sumDestryed}");
            if (sumDestryed != 0)
            {
                foreach (Planet planet in planets.Where(x => x.TypeAttack == 'D').OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-> {planet.Name}");
                }
            }
        }
    }
}
