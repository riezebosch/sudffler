using FluentAssertions;
using Xunit;

namespace Swapper.Tests;

public class Column
{
    [Fact]
    public void Test1()
    {
        var input =
            "1234" +
            "3412" +
            "2341" +
            "4123";

        var output = Swap.Column(input, 0, 1);
        output.Should().Be(
            "2134" +
            "4312" +
            "3241" +
            "1423");
    }
    
    [Fact]
    public void Second()
    {
        var input =
            "1234" +
            "1234" +
            "1234" +
            "1234";

        var output = Swap.Column(input, 2, 3);
        output.Should().Be(
            "1243" +
            "1243" +
            "1243" +
            "1243");
    }

    [Fact]
    public void Larger()
    {
        Grid input =
            "123444444" +
            "123444444" +
            "123444444" +
            "123444444" +
            "123444444" +
            "123444444" +
            "123444444" +
            "123444444" +
            "123444444";

        Grid expected = 
            "213444444" +
            "213444444" +
            "213444444" +
            "213444444" +
            "213444444" +
            "213444444" +
            "213444444" +
            "213444444" +
            "213444444";
        
        Swap.Column(input, 0, 1).Should().Be(expected);
    }
    
    [Fact]
    public void Offset()
    {
        Grid input =
            "123444444" +
            "123444444" +
            "123444444" +
            "123444444" +
            "123444444" +
            "123444444" +
            "123444444" +
            "123444444" +
            "123444444";

        Grid expected = 
            "321444444" +
            "321444444" +
            "321444444" +
            "321444444" +
            "321444444" +
            "321444444" +
            "321444444" +
            "321444444" +
            "321444444";
        
        Swap.Column(input, 0, 2).Should().Be(expected);
    }
}