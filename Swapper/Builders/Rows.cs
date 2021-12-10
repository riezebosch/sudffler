namespace Swapper.Builders;

internal class Rows : IRows
{
    private readonly Builder _builder;

    public Rows(Builder builder) => _builder = builder;
    public Builder Mirror() => _builder.Add(grid => grid.Rows());
}