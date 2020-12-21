using System;
using System.Collections.Generic;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var passports = new List<Passport>();

            var path = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, args[0]));
            var file = new StringReader(path);

            var passport = "";
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if (line != "")
                {
                    passport += " " + line;
                } else
                {
                    passports.Add(new Passport(passport));
                    passport = "";
                }
            }
            file.Close();
            Console.WriteLine("Hello World!");
        }
    }
}
