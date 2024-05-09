/*
Async/await
The Test method given in the exercise uses 
the DownloadDataAsync method, which currently does not exist.

Implement this method in such a way that the code 
compiles without issues. This method should:

Be asynchronous

Wait for 1 second

Print to the console "Content from URL 'FIRST_PARAM' is 'SECOND_PARAM'", 
where FIRST_PARAM and SECOND_PARAM should be replaced with values of 
the method parameters.
 
 */

using System;

namespace Coding.Exercise
{
    public class Exercise
    {
        public async void Test()
        {
            string data = await DownloadDataAsync("test.com", "some content");
            Console.WriteLine(data);
        }

        public async Task<string> DownloadDataAsync(string url, string data)
        {
            await Task.Delay(1000);
            return $"Content from URL \'{url}\' is \'{data}\'";
        }
    }
}
