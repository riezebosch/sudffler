using FluentAssertions;
using Xunit;

namespace Swapper.Tests;

public class Shuffler
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

        input.Shuffle("1234", "ABCD").Should().Be(expected);
    }
    
    [Fact]
    public static void Shuffled()
    {
        Grid input =
            "1234" +
            "3412" +
            "2341" +
            "4123";

        input.Shuffle("1234").Should().NotBe(input);
    }
    
    [Fact]
    public static void Ignored()
    {
        Grid input =
            ".234" +
            "3412" +
            "2341" +
            "4123";

        input.Shuffle("1234").ToString().Should().Match(".*");
    }
}