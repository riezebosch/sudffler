using System;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Swapper.Tests.Shuffle;

public class Stack
{
    [Fact]
    public void Test()
    {
        Grid input =
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "";
        
        Grid expected =
            "231456789" +
            "231456789" +
            "231456789" +
            "231456789" +
            "231456789" +
            "231456789" +
            "231456789" +
            "231456789" +
            "231456789" +
            "";

        var rnd = Substitute.For<Random>();
        rnd.Next(3).Returns(1);

        rnd.Shuffle().Stack(input, 0).Should().Be(expected);
    }
    
    [Fact]
    public void Other()
    {
        Grid input =
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "123456789" +
            "";
        
        Grid expected =
            "123564789" +
            "123564789" +
            "123564789" +
            "123564789" +
            "123564789" +
            "123564789" +
            "123564789" +
            "123564789" +
            "123564789" +
            "";

        var rnd = Substitute.For<Random>();
        rnd.Next(3).Returns(1);

        rnd.Shuffle().Stack(input, 1).Should().Be(expected);
    }
    
    [Fact]
    public void Uneven()
    {
        Grid input =
            "123456" +
            "123456" +
            "123456" +
            "123456" +
            "123456" +
            "123456" +
            "";
        
        Grid expected =
            "231456" +
            "231456" +
            "231456" +
            "231456" +
            "231456" +
            "231456" +
            "";

        var rnd = Substitute.For<Random>();
        rnd.Next(3).Returns(1);

        rnd.Shuffle().Stack(input, 0).Should().Be(expected);
    }
}