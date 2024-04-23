/*
 HashSet - CreateUnion method
Implement the CreateUnion method, which takes two HashSets and builds a 
new HashSet containing all items from both input HashSets.

For example:

for set1 containing numbers {1,2,3,4,5} and set2 containing numbers 
{4,5,6}, the result shall be {1,2,3,4,5,6}

for set1 containing strings {"a", "b"} and set2 containing strings 
{"c", "d"}, the result shall be {"a", "b", "c", "d"}

This method should be pure - it should not modify the input parameters in any way.
 */

using System;

namespace Coding.Exercise
{
    public static class HashSetsUnionExercise
    {
        public static HashSet<T> CreateUnion<T>(
            HashSet<T> set1, HashSet<T> set2)
        {
            var res = new HashSet<T>(set1);
            foreach (var item in set2)
                res.Add(item);
            return res;
        }
    }
}
