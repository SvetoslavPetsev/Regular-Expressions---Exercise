using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            List<string> mails = new List<string>();
            Regex pattern = new Regex(@"\s+(?<mail>([A-Za-z0-9]+([\._-][A-Za-z0-9]+)*)@(\w+(\-\w+)*\.\w+((\-\w+)*\.\w+)*))");

            MatchCollection mailsMatch = pattern.Matches(text);
            foreach (Match mail in mailsMatch)
            {
                string mailName = mail.Value;
                mails.Add(mailName);
            }
            foreach (var item in mails)
            {
                Console.WriteLine(item);
            }
        }
    }
}
