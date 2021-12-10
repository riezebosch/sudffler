using FluentAssertions;
using Xunit;

namespace Swapper.Tests;

public class MirrorTests
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

        Mirror.Columns(input).Should().Be(expected);
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

        input.Stack(0).Should().Be(expected);
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
            "3412" +
            "3412" +
            "3412" +
            "3412";

        input.Stacks().Should().Be(expected);
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

        input.Rows().Should().Be(expected);
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

        Mirror.Band(input, 0).Should().Be(expected);
    }
    
    [Fact]
    public void Bands()
    {
        Grid input =
            "1111" +
            "2222" +
            "3333" +
            "4444" + 
            "";
        
        Grid expected =
            "3333" +
            "4444" +
            "1111" +
            "2222" +
            "";

        Mirror.Bands(input).Should().Be(expected);
    }
}