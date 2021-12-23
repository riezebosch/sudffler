using FluentAssertions;
using Xunit;

namespace Swapper.Tests.Mirror;

public static class Stack
{
    [Fact]
    public static void First()
    {
        Swapper.Grid input =
            "1234" +
            "1234" +
            "1234" +
            "1234";
        
        Swapper.Grid expected =
            "2134" +
            "2134" +
            "2134" +
            "2134";

        Swapper.Mirror.Stack(input, 0).Should().Be(expected);
    }

    [Fact]
    public static void StackUneven()
    {
        Swapper.Grid input =
            "123456" +
            "123456" +
            "123456" +
            "123456" +
            "123456" +
            "123456";
        
        Swapper.Grid expected =
            "213456" +
            "213456" +
            "213456" +
            "213456" +
            "213456" +
            "213456";

        Swapper.Mirror.Stack(input, 0).Should().Be(expected);
    }

    [Fact]
    public static void Stacks()
    {
        Swapper.Grid input =
            "1234" +
            "1234" +
            "1234" +
            "1234";
        
        Swapper.Grid expected =
            "3412" +
            "3412" +
            "3412" +
            "3412";

        Swapper.Mirror.Stacks(input).Should().Be(expected);
    }

    [Fact]
    public static void Uneven()
    {
        Swapper.Grid input =
            "111222" +
            "111222" +
            "111222" +
            "111222" +
            "111222" +
            "111222";
        
        Swapper.Grid expected =
            "222111" +
            "222111" +
            "222111" +
            "222111" +
            "222111" +
            "222111";

        Swapper.Mirror.Stacks(input).Should().Be(expected);
    }
}