using FluentAssertions;
using Xunit;

namespace Swapper.Tests;

public class Row
{
    [Fact]
    public void Test1()
    {
        Grid input =
            "1234" +
            "3412" +
            "2341" +
            "4123";

        Grid expected = 
            "3412" +
            "1234" +
            "2341" +
            "4123";
        
        input.Row(0, 1).Should().Be(expected);
    }
    
    [Fact]
    public void Second()
    {
        Grid input =
            "1111" +
            "2222" +
            "3333" +
            "4444";

        Grid expected = 
            "1111" +
            "2222" +
            "4444" +
            "3333";
        
        input.Row(2, 3).Should().Be(
            expected);
    }
    
    [Fact]
    public void Larger()
    {
        Grid input =
            "111111111" +
            "222222222" +
            "333333333" +
            "333333333" +
            "333333333" +
            "333333333" +
            "333333333" +
            "333333333" +
            "444444444";

        Grid expected = 
            "222222222" +
            "111111111" +
            "333333333" +
            "333333333" +
            "333333333" +
            "333333333" +
            "333333333" +
            "333333333" +
            "444444444";
        
        input.Row(0, 1).Should().Be(expected);
    }
    
    [Fact]
    public void Offset()
    {
        Grid input =
            "111111111" +
            "222222222" +
            "333333333" +
            "333333333" +
            "333333333" +
            "333333333" +
            "333333333" +
            "333333333" +
            "444444444";

        Grid expected =
            "333333333" +
            "222222222" +
            "111111111" +
            "333333333" +
            "333333333" +
            "333333333" +
            "333333333" +
            "333333333" +
            "444444444";
        
        input.Row(0, 2).Should().Be(expected);
    }
}