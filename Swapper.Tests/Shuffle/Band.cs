using System;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Swapper.Tests.Shuffle;

public class Band
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
            "2222" +
            "1111" +
            "3333" +
            "4444" +
            "";

        var rnd = Substitute.For<Random>();
        rnd.Next(2).Returns(1);

        new Shuffler(rnd).Band(input, 0).Should().Be(expected);
    }
    
    [Fact]
    public void Second()
    {
        Grid input =
            "1111" +
            "2222" +
            "3333" +
            "4444" +
            "";
        
        Grid expected =
            "1111" +
            "2222" +
            "4444" +
            "3333" +
            "";

        var rnd = Substitute.For<Random>();
        rnd.Next(2).Returns(1);

        new Shuffler(rnd).Band(input, 1).Should().Be(expected);
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
            "222222" +
            "111111" +
            "333333" +
            "444444" +
            "555555" +
            "666666" +
            "";

        var rnd = Substitute.For<Random>();
        rnd.Next(3).Returns(1);

        new Shuffler(rnd).Band(input, 0).Should().Be(expected);
    }
}