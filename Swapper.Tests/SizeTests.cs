using FluentAssertions;
using Xunit;

namespace Swapper.Tests;

public static class SizeTests
{
    [Fact]
    public static void Size81()
    {
        var size = new Size(81);
        size.C.Should().Be(3);
        size.R.Should().Be(3);
    }
    
    [Fact]
    public static void Size36()
    {
        var size = new Size(36);
        size.C.Should().Be(3);
        size.R.Should().Be(2);
    }
}