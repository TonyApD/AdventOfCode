using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    internal class Seat
    {
        internal int Row { get; }

        internal int Column { get; }

        internal Seat(int row, int column)
        {
            Row = row;
            Column = column;
        }

        internal int GetSeatId()
        {
            return Row * 8 + Column;
        }
    }
}
