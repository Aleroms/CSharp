using System;

namespace Coding.Exercise
{
    public class Dog
    {
        private string _name;
        private string _breed;
        private int _weight;

        public Dog(string name, string breed, int weight)
        {
            _name = name;
            _breed = breed;
            _weight = weight;
        }
        public Dog(string name, int weight) : this(name, "mixed-breed", weight) { }
        public string Describe()
        {
            string weightDescription = _weight < 5 ? "tiny" : _weight >= 5 && _weight < 30 ? "medium" : "large";
            return $"This dog is named {_name}, it's a {_breed}, and it weighs {_weight} kilograms, so it's a {weightDescription} dog.";
        }
    }
}
