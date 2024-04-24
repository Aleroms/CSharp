/*
 Floating point numbers - The IsAverageEqualTo method
Implement the IsAverageEqualTo extension method for collections of doubles. 
Except for the collection, it takes the valueToBeChecked double parameter.

This method calculates the average of items in the collection, 
and it returns true if this average is equal to the valueToBeChecked within 
the tolerance of 0.00001.



For example:

For input {1d, 2d, 3d} and valueToBeChecked equal to 2.00000000000001, 
the result shall be true because the average value in the collection is 2, 
so it is equal to valueToBeChecked within the tolerance.

For input {1d, 2d, 3d} and valueToBeChecked equal to 2.1, the result shall 
be false because the average value in the collection is 2, so it is not equal 
to valueToBeChecked within the tolerance.

Important: if any item in the input collection is a NaN or Infinity, 
the method should throw ArgumentException.



Tip: you can check if a number is Nan or Infinity like this:






Don't simply check the equality of a number and NaN value like this, 
as it will not work:


 
 */
using System;

namespace Coding.Exercise
{
    public static class FloatingPointNumbersExercise
    {
        public static bool IsAverageEqualTo(
            this IEnumerable<double> input, double valueToBeChecked)
        {
            double sum = 0.0;
            int count = 0;
            foreach (double number in input)
            {
                if (double.IsNaN(number) || double.IsInfinity(number))
                {
                    throw new ArgumentException("Input contains NaN or Infinity values.");
                }
                sum += number;
                count++;
            }
            var average = sum / count;
            const double tolerance = 0.00001;
            return Math.Abs(average - valueToBeChecked) < tolerance;
        }
    }
}
