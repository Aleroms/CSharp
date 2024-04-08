using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public List<string> GetOnlyUpperCaseWords(List<string> words)
        {

            var result = new List<string>();
            foreach (var word in words)
            {

                bool flag = true;

                foreach (char character in word)
                {

                    if (!char.IsUpper(character))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag && !result.Contains(word))
                    result.Add(word);
            }
            return result;
        }
    }
}
