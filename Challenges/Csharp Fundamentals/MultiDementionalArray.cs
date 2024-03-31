using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public static int FindMax(int[,] numbers)
        {
            if (numbers.Length == 0) return -1;

            int max = int.MinValue;
            int h = numbers.GetLength(0);
            int w = numbers.GetLength(1);

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (numbers[i, j] > max) max = numbers[i, j];
                }
            }
            return max;
        }
    }
}
