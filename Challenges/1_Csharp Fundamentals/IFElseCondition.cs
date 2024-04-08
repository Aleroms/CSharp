using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public static string IsElseConditionalStatement()
        {
            int number = 0;

            string result = number < 0 ? "negative" : number == 0 ? "zero" : "positive";

            return result;
        }
    }
}