/*
 Type constraints & IComparable - SortedList of FullNames
Finalize the implementation of the given program.
The SortedList is a wrapper for a collection. It sorts the collection given in the constructor using the Sort method.
The FullName class holds two string properties - FirstName and LastName.



We want to be able to create a SortedList<FullName> object. 
The names stored in the Items collection should be sorted first by LastName, then by FirstName.

For example, for the following collection of FullNames passed as the constructor argument:

John Smith, Anna Smith, Kenji Narasaki, John Watson

The Items collection of the SortedList should contain FullNames objects in the following order:

Kenji Narasaki, Anna Smith, John Smith, John Watson

Kenji Narasaki is first because his last name is first in alphabetical order.
Two people with the same last name (John Smith and Anna Smith) are ordered by their first names. 
The last in the order is John Watson because his last name is last in alphabetical order.



You will need to:

Specify a proper type constraint in the SortedList class. Only classes that can be ordered should be used as the T parameter.

Make FullName class implement a proper interface that will allow the ordering of objects of this class.
 
 */


using System;

namespace Coding.Exercise
{
    public class SortedList<T> where T : IComparable<T>
    {
        public IEnumerable<T> Items { get; }

        public SortedList(IEnumerable<T> items)
        {
            var asList = items.ToList();
            asList.Sort();
            Items = asList;
        }
        public int CompareTo(T item)
        {

        }
    }

    public class FullName : IComparable<FullName>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public override string ToString() => $"{FirstName} {LastName}";

        public int CompareTo(FullName other)
        {
            var lastNameComparison = LastName.CompareTo(other.LastName);
            if (lastNameComparison != 0)
            {
                return lastNameComparison;
            }
            else return FirstName.CompareTo(other.FirstName);
        }
    }
}