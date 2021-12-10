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
            .Rotate()
            ;
        
        Grid starter = "EA030C000010000000002B000000640AG8C070302F00005E07000100ED000B0CF452000000G700E000000000900000BF000GE701D0FB9600000E000560427D0000F68509300020000027B30G4095F0008B000002000000000E006A000000B841903000AB007000F05G00002E0A0F09DB60BD00000034000000000G0000D03087";
        _output.WriteLine(builder.Apply(starter).ToString());

        Grid solution = "513246246135624351135624351462462513"; 
        _output.WriteLine(builder.Apply(solution).ToString());
    }
}