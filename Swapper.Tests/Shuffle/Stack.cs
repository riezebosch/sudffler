using System;
using FluentAssertions;
using NSubstitute;
using Swapper.Shuffle;
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

        new Swapper.Shuffle.Stack(rnd).Apply(input).Should().Be(expected);
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
            "";;

        var rnd = Substitute.For<Random>();
        rnd.Next(3).Returns(1);

        new Swapper.Shuffle.Stack(rnd).Apply(input).Should().Be(expected);
    }
}