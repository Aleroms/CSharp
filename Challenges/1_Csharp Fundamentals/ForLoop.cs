using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public static int Factorial(int number)
        {
            int _factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                _factorial *= i;
            }
            return _factorial;
        }
    }
}
