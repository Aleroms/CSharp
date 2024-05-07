/*
Handling exceptions with continuations
Finish the implementation of the Test method. This method calls 
the ParseToIntAndPrint method which may throw three kinds of exceptions:



ArgumentNullException, which should be handled by printing 
"The input is null." to the console.

FormatException, which should be handled by printing "The input is 
not in a correct format." to the console.

ArgumentOutOfRangeException, which should NOT be handled. If this 
exception is thrown within the ParseToIntAndPrint method, then "Unexpected exception type."
should be printed to the console, and the task should become faulted.

If no exception is thrown, then the task should successfully run to completion.
 */

using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public static Task Test(string? input)
        {
            var task = Task.Run(() => ParseToIntAndPrint(input))
             .ContinueWith(
                 faultedTask =>
                 {
                     faultedTask.Exception.Handle(ex =>
                     {
                         if (ex is ArgumentNullException)
                         {
                             Console.WriteLine("The input is null.");
                             return true;
                         }
                         if (ex is FormatException)
                         {
                             Console.WriteLine("The input is not in a correct format.");
                             return true;
                         }
                         Console.WriteLine("Unexpected exception type.");
                         return false;
                     });
                 },
                 TaskContinuationOptions.OnlyOnFaulted
                 );

            return task;
        }

        private static void ParseToIntAndPrint(string? input)
        {
            if (input is null)
            {
                throw new ArgumentNullException();
            }

            if (long.TryParse(input, out long result))
            {
                if (result > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("The number is too big for an int.");
                }
                Console.WriteLine("Parsing successful, the result is: " + result);
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}
