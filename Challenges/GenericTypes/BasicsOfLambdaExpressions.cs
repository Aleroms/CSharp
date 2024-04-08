using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public Func<string, int> GetLength = s => s.Length;
        public Func<int> GetRandomNumberBetween1And10 = () => new Random().Next(1, 11);
    }
}
