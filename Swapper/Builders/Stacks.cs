namespace Swapper.Builders;

internal class Stacks : IStacks
{
    private readonly Builder _builder;

    public Stacks(Builder builder) => _builder = builder;
    public Builder Mirror() => _builder.Add(grid => grid.Stacks());
    public Builder Shuffle() => _builder.Add((grid, random) => new Shuffler(random).Stacks(grid));
    public Builder ForEach(Action<IStack> apply) => _builder.Add(grid =>
    {
        var builder = new Builder();
        var stacks = grid.Size.Lower().Lower();
            
        for (var stack = 0; stack < stacks; stack++)
        {
            apply(new Stack(builder, stack));
        }

        return builder.Apply(grid);
    });
}