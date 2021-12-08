using FluentAssertions;
using Xunit;

namespace Swapper.Tests;

public class Mirror
{
    [Fact]
    public void Columns()
    {
        Grid input =
            "1234" +
            "1234" +
            "1234" +
            "1234";
        
        Grid expected =
            "4321" +
            "4321" +
            "4321" +
            "4321";

        input.MirrorColumns().Should().Be(expected);
    }
    
    [Fact]
    public void Stack()
    {
        Grid input =
            "1234" +
            "1234" +
            "1234" +
            "1234";
        
        Grid expected =
            "2134" +
            "2134" +
            "2134" +
            "2134";

        input.MirrorStack(0).Should().Be(expected);
    }
    
    [Fact]
    public void Stacks()
    {
        Grid input =
            "1234" +
            "1234" +
            "1234" +
            "1234";
        
        Grid expected =
            "2143" +
            "2143" +
            "2143" +
            "2143";

        input.MirrorStacks().Should().Be(expected);
    }
    
    [Fact]
    public void Rows()
    {
        Grid input =
            "1111" +
            "2222" +
            "3333" +
            "4444";
        
        Grid expected =
            "4444" +
            "3333" +
            "2222" +
            "1111";

        input.MirrorRows().Should().Be(expected);
    }
    
    [Fact]
    public void Band()
    {
        Grid input =
            "1111" +
            "2222" +
            "3333" +
            "4444";
        
        Grid expected =
            "2222" +
            "1111" +
            "3333" +
            "4444";

        input.MirrorBand(0).Should().Be(expected);
    }
    
    [Fact]
    public void Bands()
    {
        Grid input =
            "1111" +
            "2222" +
            "3333" +
            "4444";
        
        Grid expected =
            "2222" +
            "1111" +
            "4444" +
            "3333";

        input.MirrorBands().Should().Be(expected);
    }
}