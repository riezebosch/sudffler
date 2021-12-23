using FluentAssertions;
using Xunit;

namespace Swapper.Tests.Mirror;

public static class Grid
{
    [Fact]
    public static void Rows()
    {
        Swapper.Grid input =
            "1111" +
            "2222" +
            "3333" +
            "4444";
        
        Swapper.Grid expected =
            "4444" +
            "3333" +
            "2222" +
            "1111";

        Swapper.Mirror.Rows(input).Should().Be(expected);
    }

    [Fact]
    public static void Columns()
    {
        Swapper.Grid input =
            "1234" +
            "1234" +
            "1234" +
            "1234";
        
        Swapper.Grid expected =
            "4321" +
            "4321" +
            "4321" +
            "4321";

        Swapper.Mirror.Columns(input).Should().Be(expected);
    }
}