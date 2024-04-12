/*
 GetHashCode - Time struct
For the Time struct consisting of Hour and Minute integers, 
override the Equals and GetHashCode methods, 
so they support value-based behavior.
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

        public override bool Equals(object obj) =>
            obj is Time t && Hour == t.Hour && Minute == t.Minute;

        public override int GetHashCode() =>
            HashCode.Combine(Hour, Minute);

    }
}
