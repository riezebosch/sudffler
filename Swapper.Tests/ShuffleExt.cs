using System;
using FluentAssertions;
using Xunit;

namespace Swapper.Tests;

public static class ShuffleExt
{
    [Fact]
    public static void Test1()
    {
        Grid input =
            "1234" +
            "3412" +
            "2341" +
            "4123";
        
        Grid expected = 
            "ABCD" +
            "CDAB" +
            "BCDA" +
            "DABC";

        new Random().Shuffle().Alphabet(input, "1234", "ABCD").Should().Be(expected);
    }
    
    [Fact]
    public static void Shuffled()
    {
        Grid input =
            "1234" +
            "3412" +
            "2341" +
            "4123";

        new Random().Shuffle().Alphabet(input, "1234").Should().NotBe(input);
    }
    
    [Fact]
    public static void Ignored()
    {
        Grid input =
            ".234" +
            "3412" +
            "2341" +
            "4123";
        
        Grid expected =
            ".BCD" +
            "CDAB" +
            "BCDA" +
            "DABC";

        new Random().Shuffle()
            .Alphabet(input, "1234", "ABCD")
            .Should()
            .Be(expected);
    }
}