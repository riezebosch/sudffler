using System;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Swapper.Tests.Shuffle;

public class Bands
{
    [Fact]
    public void Test()
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

        var rnd = Substitute.For<Random>();
        rnd.Next(2).Returns(1);

        rnd.Shuffle().Bands(input).Should().Be(expected);
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
            "666666" +
            "";
        
        Grid expected =
            "333333" +
            "444444" +
            "555555" +
            "666666" +
            "111111" +
            "222222" +
            "";

        var rnd = Substitute.For<Random>();
        rnd.Next(3).Returns(1);

        rnd.Shuffle().Bands(input).Should().Be(expected);
    }
}