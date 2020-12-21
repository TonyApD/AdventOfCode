using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        private const int NumberOfRows = 128;
        private const int NumberOfColumns = 8;
        static void Main(string[] args)
        {
            var path = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, args[0]));
            var file = new StringReader(path);

            var seats = new List<Seat>();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var seatInput = line.ToCharArray();
                var seat = new Seat(GetSeatIndex(seatInput.Take(7).ToArray(), NumberOfRows, 'B', 'F'), GetSeatIndex(seatInput.Skip(7).ToArray(), NumberOfColumns, 'R', 'L'));
                seats.Add(seat);
            }
            file.Close();

            ExecutePart1(seats);
            ExecutePart2(seats);
        }

        private static void ExecutePart1(IEnumerable<Seat> seats)
        {
            var highestSeatId = seats.Max(s => s.GetSeatId());
            Console.WriteLine($"Part 1: Highest seat id: {highestSeatId}");
        }

        private static void ExecutePart2(IEnumerable<Seat> seats)
        {
            var minSeat = seats.Min(s => s.GetSeatId());
            var maxSeat = seats.Max(s => s.GetSeatId());
            var seatIds = seats.Select(x => x.GetSeatId());
            for (int i = minSeat; i < maxSeat; i++)
            {
                if (!seatIds.Contains(i)) {
                    Console.WriteLine($"Part 2: Your seat ID is: {i}");
                }
            }
        }

        /// <summary>
        /// Gets the index based on the input
        /// </summary>
        /// <param name="input">The part of the input which should be used to determine the index.</param>
        /// <param name="maxNumber">The maximum number in which the input can result.</param>
        /// <param name="upper">The char which indicates we need to go to the upper index.</param>
        /// <param name="lower">The char which indicates we need to go to the lower index.</param>
        /// <returns></returns>
        private static int GetSeatIndex(char[] input, int maxNumber, char upper, char lower)
        {
            var startIndex = 0;
            var endIndex = maxNumber - 1;
            foreach (var position in input)
            {
                if (position == lower)
                {
                    endIndex = (endIndex + startIndex) / 2;
                }
                else if (position == upper)
                {
                    startIndex += (endIndex - startIndex + 1) / 2;
                }
            }
            return startIndex;
        }
    }
}
