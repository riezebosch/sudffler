namespace Swapper.Builders;

internal class Band : IBand
{
    private readonly Builder _builder;
    private readonly int _band;

    public Band(Builder builder, int band) => (_builder, _band) = (builder, band);
    public Builder Swap(int with) => _builder.Add(grid => Swapper.Swap.Band(grid, _band, with));
    public Builder Mirror() => _builder.Add(grid => Swapper.Mirror.Band(grid, _band));
    public Builder Shuffle() => _builder.Add((grid, random) => random.Shuffle().Band(grid, _band));
}