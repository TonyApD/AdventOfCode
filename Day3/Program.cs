using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new List<string>();

            var path = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, args[0]));
            var file = new StringReader(path);

            string line;
            while ((line = file.ReadLine()) != null)
            {
                map.Add(line);
            }
            file.Close();

            ExecutePart1(map);
            ExecutePart2(map);
        }

        private static void ExecutePart1(IEnumerable<string> map)
        {
            var slope = new Slope(3, 1);
            var numberOfTrees = TraverseSlope(map, slope);
            Console.WriteLine($"Part1 - Number of trees: {numberOfTrees}");
        }

        private static void ExecutePart2(IEnumerable<string> map)
        {
            var slopes = new List<Slope>
            {
                new Slope(1, 1),
                new Slope(3, 1),
                new Slope(5, 1),
                new Slope(7, 1),
                new Slope(1, 2)
            };

            var product = 1L;
            foreach (var slope in slopes)
            {
                var numberOfTrees = TraverseSlope(map, slope);
                Console.WriteLine($"Part2 - Number of trees: {numberOfTrees} {product}");
                product *= numberOfTrees;
            }
            Console.WriteLine($"Part 2 - Number of trees product: {product}");
        }

        public static int TraverseSlope(IEnumerable<string> map, Slope slope)
        {
            var xPos = 0;
            for (int i = 0; i < map.Count(); i += slope.StepsDown)
            {
                var current = map.ElementAt(i);
                var currentChar = current.ToCharArray()[xPos % current.Length];

                if (currentChar == '#')
                {
                    slope.AddTree();
                }
                xPos += slope.StepsRight;
            }
            return slope.NumberOfTrees;
        }
    }
}
