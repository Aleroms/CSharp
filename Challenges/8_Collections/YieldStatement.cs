/*
 yield statement - GetAllAfterLastNullReversed method
Implement the GetAllAfterLastNullReversed as an iterator method.

This method takes an IList of some objects. It should return all 
objects occurring after the last null in this list but in a reversed order.

For example:

For input {"a", "b", null, "d", "e", "f"}, the result shall be 
{"f", "e", "d"} because the strings after the last null are "d", "e", "f", 
and we want to return them in reversed order.

For input {"a", "b", null, "d", "e", "f", null, "h", "i"}, the result shall be 
{"i", "h"}, because the strings after the last null are "h", "i" and we want to 
return them in reversed order.
 */
using System;

namespace Coding.Exercise
{
    public class YieldExercise
    {
        public static IEnumerable<T> GetAllAfterLastNullReversed<T>(IList<T> input)
        {
            for (int i = input.Count - 1; i > 0; i--)
            {
                if (input[i] is null)
                {
                    yield break;
                }
                yield return input[i];
            }
        }
    }
}
