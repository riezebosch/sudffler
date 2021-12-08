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
        var alphabet = "123456";
        var becomes = alphabet.Shuffle();
        
        Grid starter = "000200040030004001100600050060002000";
        _output.WriteLine(starter
            .Shuffle(alphabet, becomes)
            .Stack(0, 1)
            .Band(0, 1)
            .ToString());

        Grid solution = "513246246135624351135624351462462513";
        _output.WriteLine(solution
            .Shuffle(alphabet, becomes)
            .Stack(0, 1)
            .Band(0, 1)
            .ToString());
    }
}