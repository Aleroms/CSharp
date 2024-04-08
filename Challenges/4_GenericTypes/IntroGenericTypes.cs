/*
Generic types - Pair class
Implement the generic Pair type as follows:

It should be a container for two items of the same type.

It should have two properties called First and Second of the type that parameterized this class. 
Both those properties should be publically gettable but should not be publically settable.

It should have a constructor taking two parameters that sets First and Second properties

This class should expose public ResetFirst and ResetSecond methods that set the First or 
the Second property to the default values for their type.



For example, this is how we may want to use this class:
var pairOfInts = new Pair<int>(1,2);
Console.WriteLine("First is " + pairOfInts.First);
Console.WriteLine("Second is " + pairOfInts.Second);
pairOfInts.ResetFirst(); // will set First to 0
 
 */


using System;

namespace Coding.Exercise
{
    public class Pair<T>
    {
        public T First { get; private set; }
        public T Second { get; private set; }

        public Pair(T f, T s)
        {
            First = f;
            Second = s;
        }
        public void ResetFirst()
        {
            First = default(T);
        }
        public void ResetSecond()
        {
            Second = default(T);
        }
    }
}
