/*
 Operators overloading - Time structs
We will continue the implementation of the Time struct.

It has two properties of type int: Hour and Minute. Both are already 
validated to represent valid values (Hour will be between 0 and 23, and Minute between 0 and 59).

Your job is to:

Overload both the == and != operators so that they compare two Time objects by the values 
of those two properties.

Overload the + operator.

The + operator shall be overloaded to calculate the sum of times. 
For example, if the first Time is 10:30, and the second Time is 1:00,
the result of the addition is 11:30, so simply 1 hour after 10:30.



So in practice, the + operator shall add Hours and Minutes of both objects.
If the sum exceeds the valid values, they shall be properly trimmed.

For example:

When adding 11:15 to 1:10, the result shall be 12:25. In this case no trimming is needed.

When adding 11:15 to 1:55, the result shall be 13:10. The sum of minutes is 70, which is more than 59,
so it is trimmed to 15, and one extra hour is added to the sum of hours.

When adding 11:15 to 15:10, the result shall be 2:25. The sum of hours is 26, but this is not a valid hour,
so we trim it to represent hour 2 (of the next day).
 */
using System;

namespace Coding.Exercise
{
    public struct Time
    {
        public int Hour { get; }
        public int Minute { get; }

        public Time(int hour, int minute)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(
                    "Hour is out of range of 0-23");
            }
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(
                    "Minute is out of range of 0-59");
            }
            Hour = hour;
            Minute = minute;
        }

        public override string ToString() =>
            $"{Hour.ToString("00")}:{Minute.ToString("00")}";

        public static bool operator ==(Time t1, Time t2) =>
            t2.Hour == t1.Hour && t2.Minute == t1.Minute;

        public static bool operator !=(Time t1, Time t2) =>
            !(t1 == t2);

        public static Time operator +(Time t1, Time t2)
        {
            var hr = t1.Hour + t2.Hour;
            var min = t1.Minute + t2.Minute;
            if (min > 59)
            {
                hr++;
                min -= 60;
            }

            return new Time(hr % 24, min);
        }
    }

}
