using FluentAssertions;
using Xunit;

namespace Swapper.Tests;

public static class GridTests
{
    [Fact]
    public static void Equal() => 
        new Grid("1").Should().Be(new Grid("1"));
    
    [Fact]
    public static void String() => 
        new Grid("1234").ToString().Should().Be("1234");
}