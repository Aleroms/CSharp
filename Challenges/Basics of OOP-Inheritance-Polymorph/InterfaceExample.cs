/*
Interfaces - Applying multiple transformations to a number
Implement all types necessary to make this code work:

You will need to define the INumericTransformation interface and the following classes implementing it:

By1Incrementer, whose Transform method adds 1 to the input

By2Multiplier, whose Transform method multiplies input by 2

ToPowerOf2Raiser, whose Transform method raises input to the power of 2

All those transformations will be applied to the given number, so for example, 
if the input is 4, the result of the Exercise.Transform method will be 100 because:

4 will be incremented by 1, giving 5

5 will be multiplied by 2, giving 10

10 will be raised to the power of 2, giving 100
 */

using System;

namespace Coding.Exercise
{
    public static class Exercise
    {
        public static int Transform(
            int number)
        {
            var transformations = new List<INumericTransformation>
            {
                new By1Incrementer(),
                new By2Multiplier(),
                new ToPowerOf2Raiser()
            };

            var result = number;
            foreach (var transformation in transformations)
            {
                result = transformation.Transform(result);
            }
            return result;
        }
    }

    public interface INumericTransformation
    {
        int Transform(int i);
    }
    public class By1Incrementer : INumericTransformation
    {
        public int Transform(int input) => input + 1;
    }
    public class By2Multiplier : INumericTransformation
    {
        public int Transform(int input) => input * 2;
    }
    public class ToPowerOf2Raiser : INumericTransformation
    {
        public int Transform(int input) => input * input;
    }
}
