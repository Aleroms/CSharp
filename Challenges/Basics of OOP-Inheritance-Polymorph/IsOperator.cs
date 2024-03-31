/*

"is" operator and null object -NumericTypesDescriber class
Implement the Describe method from the NumericTypesDescriber class.

This method takes any object as a parameter. If this object is any of the int, double, or decimal types, 
it should print the type's name and the object value. If the input is a different type, this method should return null.

Depending on the type of input, the Describe method should behave as follows:

for ints, the result will be, for example, "Int of value 5"

for doubles, the result will be, for example, "Double of value 5.6"

for decimals, the result will be, for example, "Decimal of value 5.7"

for any other type, the result shall be null
*/

using System;

namespace Coding.Exercise
{
    public static class NumericTypesDescriber
    {
        public static string Describe(object someObject)
        {
            string result = null;
            if (someObject is int intVal) result = "Int of value " + intVal;
            if (someObject is double doubleVal) result = "Double of value " + doubleVal;
            if (someObject is decimal decimalVal) result = "Decimal of value " + decimalVal;
            return result;
        }
    }
}
