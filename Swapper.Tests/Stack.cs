using FluentAssertions;
using Xunit;

namespace Swapper.Tests;

public class Stack
{
    [Fact]
    public void First()
    {
        Grid input =
            "1234" +
            "1234" +
            "1234" +
            "1234";
        
        Grid expected = 
            "3412" +
            "3412" +
            "3412" +
            "3412";

        Swap.Stack(input, 0, 1).Should().Be(expected);
    }
    
    [Fact]
    public void Offset()
    {
        Grid input =
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789";
        
        Grid expected = 
            "789456123" +
            "789456123" +
            "789456123" + 
            "789456123" +
            "789456123" +
            "789456123" +
            "789456123" +
            "789456123" +
            "789456123";

        Swap.Stack(input, 0, 2).Should().Be(expected);
    }
    
    [Fact]
    public void Uneven()
    {
        Grid input =
            "123456" +
            "123456" +
            "123456" +
            "123456" +
            "123456" +
            "123456";

        
        Grid expected = 
            "456123" +
            "456123" +
            "456123" + 
            "456123" +
            "456123" +
            "456123";

        Swap.Stack(input, 0, 1).Should().Be(expected);
    }
}