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
            .Swap.Stack(0).With(1)
            .Swap.Band(0).With(1)
            .Mirror.Bands()
            .Mirror.Columns();
        
        Grid starter = "000200040030004001100600050060002000";
        _output.WriteLine(builder.Apply(starter).ToString());

        Grid solution = "513246246135624351135624351462462513"; 
        _output.WriteLine(builder.Apply(solution).ToString());
    }
}