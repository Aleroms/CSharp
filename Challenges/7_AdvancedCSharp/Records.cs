/*
Records - GpsCoordinates
Define a GpsCoordinates positional record representing a point on Earth. 
It should have two double properties: Latitude and Longitude.

This type should be immutable.
 
 */

using System;

namespace Coding.Exercise
{
    public record GpsCoordinates(double Latitude, double Longitude);
}
