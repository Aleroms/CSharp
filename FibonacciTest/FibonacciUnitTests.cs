using Fibonacci;
using NUnit.Framework;

namespace FibonacciTests;

public class FibonacciUnitTests
{
    [Test]
    public void Generate_ShallReturnZero_OnBaseCase()
    {
        var result = FibonacciClass.Generate(1);
        //left is expected
        //right is actual
        Assert.AreEqual(new List<int>() { 0 }, result);
    }
    [Test]
    public void Generate_ThrowsException_OnNLessThanZero()
    {
        Assert.Throws<ArgumentException>(
            () => FibonacciClass.Generate(-1));
    }
    [Test]
    public void Generate_ThrowsException_OnNLargerThanMax()
    {
        Assert.Throws<ArgumentException>(
            () => FibonacciClass.Generate(47));
    }
    [TestCase(5)]
    public void Generate_GetsSequence_OnNormalInput(int input)
    {
        var result = FibonacciClass.Generate(input);
        
        Assert.AreEqual(new List<int>() { 0,1,1,2,3}, result);
    }

}
