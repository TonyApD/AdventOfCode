using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var correctPasswordsPart1 = 0;
            var correctPasswordsPart2 = 0;

            var path = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, args[0]));
            var file = new StringReader(path);

            string line;
            while ((line = file.ReadLine()) != null)
            {
                var min = line.Substring(0, line.IndexOf("-"));
                var max = line.Substring(line.IndexOf("-") + 1, line.IndexOf(" ") - 2);
                var character = line.Substring(line.IndexOf(" ") + 1, line.IndexOf(":"));
                var password = line.Substring(line.IndexOf(":") + 2);

                var policy = new PasswordPolicy(int.Parse(min), int.Parse(max), character[0], password);
                
                if (policy.SatisfiesLengthConstraint())
                {
                    correctPasswordsPart1++;
                }

                if (policy.SatisfiesPositionConstraint())
                {
                    correctPasswordsPart2++;
                }
            }

            file.Close();
            Console.WriteLine($"Correct passwords 1: {correctPasswordsPart1}");
            Console.WriteLine($"Correct passwords 2: {correctPasswordsPart2}");
        }
    }
}
