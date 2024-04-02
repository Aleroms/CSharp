/*
 * Generic methods - SwapTupleItems method
Implement the static SwapTupleItems method. 
Its purpose is to take a Tuple of two items as a parameter and, as a result, 
return a tuple in which those items are swapped.

For example:

for an input equal to Tuple<int, string>(1, "hello"), 
the result should be Tuple<string, int>("hello", 1)

for an input equal to Tuple<int, int>(1, 2), 
the result should be Tuple<int, int>(2, 1)*/

using System;

namespace Coding.Exercise
{
    public static class TupleSwapExercise
    {
        public static Tuple<T2, T1> SwapTupleItems<T1, T2>(this Tuple<T1, T2> input)
        => new Tuple<T2, T1>(input.Item2, input.Item1);

    }
}
