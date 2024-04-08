/*
 Extension methods - List extensions
Create an extension method for the List<int> type called TakeEverySecond.

This method should return a new List of ints with every second element from the input list.

For example:

for input  { 1, 5, 10, 8, 12, 4, 5 }, the result shall be { 1, 10, 12, 5 }

for input  { 1, 5, 10, 8, 12, 4, 5, 6 }, the result shall be { 1, 10, 12, 5 }

for input  { 1 } , the result shall be { 1 }

for empty input, the result shall be empty

don't handle the null input in any way (let it throw an exception)
 */

public static List<int> TakeEverySecond(this List<int> input)
{
    var result = new List<int>();
    for (int i = 0; i < input.Length; i += 2)
    {
        result.Add(input[i]);
    }
    return result;
}