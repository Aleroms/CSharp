/*
 Equals - overriding it in the FullName class
Override the Equals method in the FullName class in such a way,
that two objects of this class are considered equal if 
the First name and the Last name are the same for them.
 
 */

using System;

namespace Coding.Exercise
{
    public class FullName
    {
        public string First { get; init; }
        public string Last { get; init; }

        public override string ToString() => $"{First} {Last}";

        public override bool Equals(object? obj) =>
            obj is FullName other &&
            First == other.First &&
            Last == other.Last;
    }
}
