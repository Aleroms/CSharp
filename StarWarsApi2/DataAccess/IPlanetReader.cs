using System.Collections.Generic;

public interface IPlanetReader
{
    Task<IEnumerable<Planet>> Read();
}
