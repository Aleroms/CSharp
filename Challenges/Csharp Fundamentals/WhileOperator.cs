using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public static int CalculateSumOfNumbersBetween(int firstNumber, int lastNumber)
        {
            if (lastNumber < firstNumber) return 0;

            int sum = 0;
            while (firstNumber <= lastNumber)
            {
                sum += firstNumber;
                firstNumber++;
            }
            return sum;
        }
    }
}
