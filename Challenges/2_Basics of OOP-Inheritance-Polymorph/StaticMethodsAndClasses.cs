/*
 * 
 * Implement the static NumberToDayOfWeekTranslator class that can be used like this:
The Translate method should take a number and return a string with the name of the day of the week, according to the following:
for 1, "Monday" is returned
for 2, "Tuesday" is returned
...
for 7, "Sunday" is returned
for any other number, "Invalid day of the week" is returned
*/
using System;

namespace Coding.Exercise
{
    public static class NumberToDayOfWeekTranslator
    {

        public static string Translate(int day)
        {
            return day == 1 ? "Monday" : day == 2 ? "Tuesday"
            : day == 3 ? "Wednesday" : day == 4 ? "Thursday"
            : day == 5 ? "Friday" : day == 6 ? "Saturday"
            : day == 7 ? "Sunday" : "Invalid day of the week";
        }
    }
}
