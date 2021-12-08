using FluentAssertions;
using Xunit;

namespace Swapper.Tests;

public class BuilderTests
{
    [Fact]
    public void Shuffle()
    {
        Grid grid = "1234123412341234";
        Grid expected = "ABCDABCDABCDABCD";

        new Builder().Shuffle("1234", "ABCD").Apply(grid).Should().Be(expected);
    }
    
    [Fact]
    public void Rotate()
    {
        Grid grid = "1234";
        Grid expected = "3142";

        new Builder().Rotate().Apply(grid).Should().Be(expected);
    }

    public class Swap
    {
        [Fact]
        public void Stack()
        {
            Grid input =
                "1234" +
                "1234" +
                "1234" +
                "1234";

            Grid expected =
                "3412" +
                "3412" +
                "3412" +
                "3412";

            new Builder().Swap.Stack(0).With(1).Apply(input).Should().Be(expected);
        }

        [Fact]
        public void Band()
        {
            Grid input =
                "1111" +
                "2222" +
                "3333" +
                "4444";

            Grid expected =
                "3333" +
                "4444" +
                "1111" +
                "2222";

            new Builder().Swap.Band(0).With(1).Apply(input).Should().Be(expected);
        }
    }

    public class Mirror
    {
        [Fact]
        public void Bands()
        {
            Grid input =
                "1111" +
                "2222" +
                "3333" +
                "4444";

            Grid expected =
                "2222" +
                "1111" +
                "4444" +
                "3333";

            new Builder().Mirror.Bands().Apply(input).Should().Be(expected);
        }

        [Fact]
        public void Band()
        {
            Grid input =
                "1111" +
                "2222" +
                "3333" +
                "4444";

            Grid expected =
                "2222" +
                "1111" +
                "3333" +
                "4444" +
                "";

            new Builder().Mirror.Band(0).Apply(input).Should().Be(expected);
        }
        
        [Fact]
        public void Rows()
        {
            Grid input =
                "1111" +
                "2222" +
                "3333" +
                "4444" +
                "";

            Grid expected =
                "4444" +
                "3333" +
                "2222" +
                "1111" +
                "";

            new Builder().Mirror.Rows().Apply(input).Should().Be(expected);
        }

        [Fact]
        public void Stacks()
        {
            Grid input =
                "1234" +
                "1234" +
                "1234" +
                "1234";

            Grid expected =
                "2143" +
                "2143" +
                "2143" +
                "2143" +
                "";

            new Builder().Mirror.Stacks().Apply(input).Should().Be(expected);
        }
        
        [Fact]
        public void Stack()
        {
            Grid input =
                "1234" +
                "1234" +
                "1234" +
                "1234";

            Grid expected =
                "2134" +
                "2134" +
                "2134" +
                "2134" +
                "";

            new Builder().Mirror.Stack(0).Apply(input).Should().Be(expected);
        }
        
        [Fact]
        public void Columns()
        {
            Grid input =
                "1234" +
                "1234" +
                "1234" +
                "1234";

            Grid expected =
                "4321" +
                "4321" +
                "4321" +
                "4321" +
                "";

            new Builder().Mirror.Columns().Apply(input).Should().Be(expected);
        }
    }
}