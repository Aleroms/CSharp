using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public static string RepeatCharacter(char character, int targetLength)
        {
            string res = "";
            do
            {
                res += character;
                targetLength--;
            } while (targetLength > 0);
            return res;
        }
    }
}