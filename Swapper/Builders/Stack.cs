namespace Swapper.Builders;

internal class Stack : IStack
{
    private readonly Builder _builder;
    private readonly int _stack;

    public Stack(Builder builder, int stack) => (_builder, _stack) = (builder, stack);
    public Builder Swap(int with) => _builder.Add(grid => Swapper.Swap.Stack(grid, _stack, with));
    public Builder Mirror() => _builder.Add(grid => Swapper.Mirror.Stack(grid, _stack));
    public Builder Shuffle() => _builder.Add((grid, random) => random.Shuffle().Stack(grid, _stack));
}