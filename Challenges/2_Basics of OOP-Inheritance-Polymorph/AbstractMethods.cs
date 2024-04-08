/*
 Abstract methods - Shapes
The purpose of the exercise is to make the GetShapesAreas method work.

This method takes a collection of Shapes, and returns a collection of their areas as doubles.

A Shape's area is a double number, so a floating-point numeric type. For example, we can use doubles like this:

double someNumber = 10.05;



Your task is to:

Add the abstract Shape class in such a way that it can be used in the GetShapesAreas method

Finish the implementations of the Square, Rectangle, and Circle classes so that each has the CalculateArea method 
that can be used in GetShapesAreas method


To calculate the area of a circle, we will need the PI number. We can access it using the Math.PI constant.
 */

using System;

namespace Coding.Exercise
{
    public static class ExerciseShapes
    {
        public static List<double> GetShapesAreas(List<Shape> shapes)
        {
            var result = new List<double>();

            foreach (var shape in shapes)
            {
                result.Add(shape.CalculateArea());
            }

            return result;
        }
    }

    public abstract class Shape
    {
        public abstract double CalculateArea();
    }
    public class Square : Shape
    {
        public double Side { get; }

        public Square(double side)
        {
            Side = side;
        }

        public override double CalculateArea() => Side * Side;
    }


    public class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea() => Width * Height;
    }

    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea() => Math.PI * Radius * Radius;
    }
}
