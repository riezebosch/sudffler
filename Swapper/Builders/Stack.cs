namespace Swapper.Builders;

internal class Stack : IStack
{
    private readonly Builder _builder;
    private readonly int _stack;

    public Stack(Builder builder, int stack) => (_builder, _stack) = (builder, stack);
    public Builder Swap(int with) => _builder.Add(grid => grid.Stack(_stack, with));
    public Builder Mirror() => _builder.Add(grid => grid.Stack(_stack));
    public Builder Shuffle() => _builder.Add(grid => new Shuffler(new Random()).Stacks(grid));
}