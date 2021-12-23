using FluentAssertions;
using Xunit;

namespace Swapper.Tests.Mirror;

public static class Band
{
    [Fact]
    public static void First()
    {
        Swapper.Grid input =
            "1111" +
            "2222" +
            "3333" +
            "4444";
        
        Swapper.Grid expected =
            "2222" +
            "1111" +
            "3333" +
            "4444";

        Swapper.Mirror.Band(input, 0).Should().Be(expected);
    }
    
    [Fact]
    public static void Bands()
    {
        Swapper.Grid input =
            "1111" +
            "2222" +
            "3333" +
            "4444" + 
            "";
        
        Swapper.Grid expected =
            "3333" +
            "4444" +
            "1111" +
            "2222" +
            "";

        Swapper.Mirror.Bands(input).Should().Be(expected);
    }
}