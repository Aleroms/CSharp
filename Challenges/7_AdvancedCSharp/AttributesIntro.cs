/*
Attributes - MustBeLargerThanAttribute
Define an attribute for which it will be possible to use it like this:

public class SomeClass {
    [MustBeLargerThan(100)]
    public int Value { get; }
}


This attribute must simply carry the data given in the parenthesis. 
It should keep it in a property called Min.

This attribute should be only applicable to properties.
 */
using System;

namespace Coding.Exercise
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MustBeLargerThanAttribute : Attribute
    {

        public int Min { get; }

        public MustBeLargerThanAttribute(int min)
        {
            Min = min;
        }
    }
}
