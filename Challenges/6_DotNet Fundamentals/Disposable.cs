/*
 Dispose method - AllLinesFromTextFileReader
Finish the implementation of the AllLinesFromTextFileReader class.

It shall be possible to use it with the using statement 
so that all unmanaged resources it uses are correctly disposed of.

Its _streamReader field shall be set in the constructor using the given file path.
 */

using System;

namespace Coding.Exercise
{
    public class AllLinesFromTextFileReader : IDisposable
    {
        private readonly StreamReader _streamReader;

        public AllLinesFromTextFileReader(string filePath)
        {
            _streamReader = new StreamReader(filePath);
        }

        public List<string> ReadAllLines()
        {
            var result = new List<string>();
            while (!_streamReader.EndOfStream)
            {
                result.Add(_streamReader.ReadLine());
            }

            return result;
        }

        public void Dispose()
        {
            _streamReader.Dispose();
        }
    }
}
