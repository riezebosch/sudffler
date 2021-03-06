namespace Swapper.Builders;

internal class Stacks : IStacks
{
    private readonly Builder _builder;

    public Stacks(Builder builder) => _builder = builder;
    public Builder Mirror() => _builder.Add(Swapper.Mirror.Stacks);
    public Builder Shuffle() => _builder.Add((grid, random) => random.Shuffle().Stacks(grid));
    public Builder ForEach(Action<IStack> apply) => _builder.Add(grid =>
    {
        var builder = new Builder();
        var stacks = grid.Size.C;
            
        for (var stack = 0; stack < stacks; stack++)
        {
            apply(new Stack(builder, stack));
        }

        return builder.Apply(grid);
    });
}