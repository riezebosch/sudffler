using System;
using Xunit;
using Xunit.Abstractions;

namespace Swapper.Tests;

public class All
{
    private readonly ITestOutputHelper _output;

    public All(ITestOutputHelper output) => 
        _output = output;

    [Fact]
    public void VOK7A385W()
    {
        var builder = new Builder()
            .Shuffle("123456")
            .Stack(0).Swap(1)
            .Stack(0).Mirror()
            .Stack(0).Shuffle()
            .Stacks().Mirror()
            .Stacks().ForEach(stack => stack.Mirror())
            .Bands().ForEach(band => band.Mirror())
            .Band(0).Swap(1)
            .Band(0).Mirror()
            .Bands().Mirror()
            .Rotate();
        
        Grid starter = "105000020000306500004106000010000205";
        _output.WriteLine(builder.Apply(starter, new Random(1234)).ToString());

        Grid solution = "145623623451316542254136562314431265"; 
        _output.WriteLine(builder.Apply(solution, new Random(1234)).ToString());
    }
}