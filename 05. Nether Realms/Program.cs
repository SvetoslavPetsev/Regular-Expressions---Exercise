using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;


namespace _05._Nether_Realms
{
    public class Demon
    {
        public string Name { get; set; }
        public int Helath { get; set; }
        public double Damage { get; set; }

        public Demon(string name, int health, double damage)
        {
            this.Name = name;
            this.Helath = health;
            this.Damage = damage;
        }
    }
    class Program
    {
        static void Main()
        {
            List<Demon> demonList = new List<Demon>();
            string[] input = Regex.Split(Console.ReadLine(), @"\s*,\s*");
            foreach (string demon in input)
            {
                Regex patterHealth = new Regex(@"[^+\-*\/0-9\.]");
                Regex patternDigit = new Regex(@"-?\d+\.?\d*");
                Regex patternOpertation = new Regex(@"[*\/]");
                double damage = 0;
                int health = 0;
                MatchCollection matchesHealth = patterHealth.Matches(demon);
                MatchCollection matchesDamage = patternDigit.Matches(demon);
                MatchCollection matchesOperator = patternOpertation.Matches(demon);

                foreach (Match item in matchesHealth)
                {
                    health += char.Parse(item.Value);
                }

                foreach (Match item in matchesDamage)
                {
                    damage += double.Parse(item.Value);
                }

                foreach (Match item in matchesOperator)
                {
                    char currOpp = char.Parse(item.Value);
                    if (currOpp == '*')
                    {
                        damage *= 2;
                    }
                    else if (currOpp == '/')
                    {
                        damage /= 2;
                    }
                }

                Demon newDemon = new Demon(demon, health, damage);
                demonList.Add(newDemon);
            }
            foreach (var demon in demonList.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Helath} health, {demon.Damage:F2} damage");
            }
        }
    }
}
