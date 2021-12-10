using System;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Swapper.Tests.Shuffle
{
    public class Stacks
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
                "456789123" +
                "456789123" +
                "456789123" +
                "456789123" +
                "456789123" +
                "456789123" +
                "456789123" +
                "456789123" +
                "456789123" +
                "";

            var rnd = Substitute.For<Random>();
            rnd.Next(3).Returns(1);

            new Shuffler(rnd).Stacks(input).Should().Be(expected);
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
                "456123" +
                "456123" +
                "456123" +
                "456123" +
                "456123" +
                "456123" +
                "";

            var rnd = Substitute.For<Random>();
            rnd.Next(2).Returns(1);

            new Shuffler(rnd).Stacks(input).Should().Be(expected);
        }
    }
}