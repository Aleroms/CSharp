/*
 Immutable struct - Time
Implement the Time structs according to the following requirements:

It should be a struct
It should be immutable
It should have two get-only int properties: Hour and Minute
It should have a single constructor taking an hour and minute parameters. 
- This constructor shall throw ArgumentOutOfRangeException when:
The hour is smaller than 0 or larger than 23
The minute is smaller than 0 or larger than 59
It should override the ToString method to return time formatted as HH:MM, for example:
- For hour equal to 12 and minute equal to 20, it should give "12:20"
- For hour equal to 14 and minute equal to 1, it should give "14:01"
- For hour equal to 7 and minute equal to 12, it should give "07:12"
- For hour equal to 2 and minute equal to 3, it should give "02:03"

Tip: To pad an integer with zeros when transforming it to a string, 
we can use: number.ToString("00").
 */

using System;

namespace Coding.Exercise
{
    public struct Time
    {
        public int Hour { get; }
        public int Minute { get; }

        public Time(int h, int m)
        {
            if (h < 0 || h > 23)
                throw new ArgumentOutOfRangeException(
                    "Hour is out of range: [0,23]");

            if (m < 0 || m > 59)
                throw new ArgumentOutOfRangeException(
                    "Minute is out of range: [0,59]");

            Hour = h;
            Minute = m;
        }

        public override string ToString() =>
            $"{Hour.ToString("00")}:{Minute.ToString("00")}";

    }
}
