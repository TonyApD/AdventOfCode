using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeDay1
{
    class Program
    {
        private const int sumValue = 2020;
        static void Main(string[] args)
        {
            var numbers = new List<int>();
            var path = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, args[0]));
            var file = new StringReader(path);

            string line;
            while ((line = file.ReadLine()) != null)
            {
                var number = int.Parse(line);
                numbers.Add(number);
             }

            ExecutePart1(numbers);
            ExecutePart2(numbers);

            file.Close();
            Console.ReadLine();
        }

        private static void ExecutePart1(IEnumerable<int> numbers)
        {
            foreach(var value in numbers)
            {
                var secondValue = numbers.FirstOrDefault((x) => x + value == sumValue);
                if (secondValue > 0)
                {
                    Console.WriteLine($"{secondValue} + {value} = {sumValue}. Multiplying gives { secondValue * value }");
                    break;
                }
            }
        }

        private static void ExecutePart2(IEnumerable<int> numbers)
        {
            foreach (var value in numbers)
            {
                var neededValue = sumValue - value;
                foreach (var value2 in numbers.Where(x => x < neededValue))
                {
                    var value3 = numbers.FirstOrDefault((x) => x + value + value2 == sumValue);
                    if (value3 > 0)
                    {
                        Console.WriteLine($"{value} + {value2} + {value3} = {sumValue}. Multiplying gives { value * value2 * value3 }");
                        break;
                    }
                }
            }
        }
    }
}
