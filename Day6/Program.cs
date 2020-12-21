using System;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, args[0]));

            ExecutePart1(new StringReader(path));
            ExecutePart2(new StringReader(path));
        }

        private static void ExecutePart1(StringReader reader)
        {
            string line;
            var yesAnswers = 0;
            var groupAnswers = "";
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    yesAnswers += groupAnswers.Distinct().Count();
                    groupAnswers = "";
                }
                else
                {
                    groupAnswers += reader;
                }
            }
            reader.Close();
            yesAnswers += groupAnswers.Distinct().Count();
            Console.WriteLine($"Part 1: Sum of yes answers a group: {yesAnswers}");
        }

        private static void ExecutePart2(StringReader reader)
        {
            string line;
            var answersInGroup = 0;
            var yesAnswers = 0;
            var groupAnswers = "";
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    yesAnswers += groupAnswers.ToCharArray().Distinct().Where((x) => groupAnswers.Where(c => c == x).Count() == answersInGroup).Count();
                    groupAnswers = "";
                    answersInGroup = 0;
                }
                else
                {
                    groupAnswers += line;
                    answersInGroup++;
                }
            }
            reader.Close();
            yesAnswers += groupAnswers.ToCharArray().Distinct().Where((x) => groupAnswers.Where(c => c == x).Count() == answersInGroup).Count();
            Console.WriteLine($"Part 2: Sum of yes answers a group: {yesAnswers}");
        }
    }
}
