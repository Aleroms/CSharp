/*
 Checked - Fibonacci sequence
Implement the GetFibonacci method generating the Fibonacci sequence of a given length.

The Fibonacci sequence is a sequence of numbers for which:

The first item is 0

The second item is 1

Every next item is the sum of two of its predecessors

This is the first 10 items in this sequence:

0,1,1,2,3,5,8,13,21,34



Assumptions:

This method should be an iterator method

It should throw OverflowException if the item in the sequence exceeds the maximal value of int.
So in practice, the last argument for which the exception should not be thrown is 47
 */

using System;

namespace Coding.Exercise
{
    public static class CheckedFibonacciExercise
    {
        public static IEnumerable<int> GetFibonacci(int n)
        {
            checked
            {
                int a = -1;
                int b = 1;

                for (int i = 0; i < n; i++)
                {
                    int s = a + b;
                    yield return sum;
                    a = b;
                    b = sum;
                }
            }
        }
    }
}
