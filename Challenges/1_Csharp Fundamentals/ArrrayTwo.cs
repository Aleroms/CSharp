using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public static bool IsWordPresentInCollection(string[] words, string wordToBeChecked)
        {
            return Array.Exists(words, word => word == wordToBeChecked);
        }
    }
}
