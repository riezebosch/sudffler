namespace Swapper.Builders;

internal class Columns : IColumns
{
    private readonly Builder _builder;

    public Columns(Builder builder) => _builder = builder;
    public Builder Mirror() => _builder.Add(grid => Swapper.Mirror.Columns(grid));
}