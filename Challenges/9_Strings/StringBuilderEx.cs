/*
 StringBuilder - The Reverse method
Using the StringBuilder class, implement the Reverse method,
which takes a string and returns it reversed.

For example:

for input "abc" result shall be "cba"

for input "Hello" result shall be "olleH"

for input "" result shall be ""

for input "one two three" result shall be "eerht owt eno"
 
 */

using System;
using System.Text;

namespace Coding.Exercise
{
    public static class StringBuilderExercise
    {
        public static string Reverse(string input)
        {
            var result = new StringBuilder(input.Length);
            for (int i = input.Length - 1; i >= 0; i--)
            {
                result.Append(input[i]);
            }
            return result.ToString();
        }
    }
}

