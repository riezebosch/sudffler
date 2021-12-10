using FluentAssertions;
using Xunit;

namespace Swapper.Tests;

public class Band
{
    [Fact]
    public void Test1()
    {
        Grid input =
            "1111" +
            "2222" +
            "3333" +
            "4444";
        
        Grid expected = 
            "3333" +
            "4444" +
            "1111" +
            "2222";

        Swap.Band(input, 0, 1).Should().Be(expected);
    }
    
    [Fact]
    public void Offset()
    {
        Grid input =
            "111111111" +
            "222222222" +
            "333333333" +
            "444444444" +
            "555555555" +
            "666666666" +
            "777777777" +
            "888888888" +
            "999999999";
        
        Grid expected = 
            "777777777" +
            "888888888" +
            "999999999" +
            "444444444" +
            "555555555" +
            "666666666" +
            "111111111" +
            "222222222" +
            "333333333";

        Swap.Band(input, 0, 2).Should().Be(expected);
    }
    
    [Fact]
    public void Uneven()
    {
        Grid input =
            "111111" +
            "222222" +
            "333333" +
            "444444" +
            "555555" +
            "666666";

        Grid expected =
            "333333" +
            "444444" +
            "111111" +
            "222222" +
            "555555" +
            "666666";

        Swap.Band(input, 0, 1).Should().Be(expected);
    }
}