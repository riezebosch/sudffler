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

        Mirror.Stack(input, 0).Should().Be(expected);
    }
    
    [Fact]
    public void StackUneven()
    {
        Grid input =
            "123456" +
            "123456" +
            "123456" +
            "123456" +
            "123456" +
            "123456";
        
        Grid expected =
            "213456" +
            "213456" +
            "213456" +
            "213456" +
            "213456" +
            "213456";

        Mirror.Stack(input, 0).Should().Be(expected);
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

        Mirror.Stacks(input).Should().Be(expected);
    }
    
    [Fact]
    public void Uneven()
    {
        Grid input =
            "111222" +
            "111222" +
            "111222" +
            "111222" +
            "111222" +
            "111222";
        
        Grid expected =
            "222111" +
            "222111" +
            "222111" +
            "222111" +
            "222111" +
            "222111";

        Mirror.Stacks(input).Should().Be(expected);
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

        Mirror.Rows(input).Should().Be(expected);
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