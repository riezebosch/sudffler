namespace Swapper;

public class Builder
{
    private readonly List<Func<Grid, Grid>> _mutators = new();
    public ISwap Swap => new SwapBuilder(this);
    public IMirror Mirror => new MirrorBuilder(this);

    private class MirrorBuilder : IMirror
    {
        private readonly Builder _builder;

        public MirrorBuilder(Builder builder) => _builder = builder;
        public Builder Band(int i) => _builder.Add(grid => grid.MirrorBand(i));
        public Builder Bands() => _builder.Add(grid => grid.MirrorBands());
        public Builder Rows() => _builder.Add(grid => grid.MirrorRows());
        public Builder Stacks() => _builder.Add(grid => grid.MirrorStacks());
        public Builder Stack(int i) => _builder.Add(grid => grid.MirrorStack(i));
        public Builder Columns() => _builder.Add(grid => grid.MirrorColumns());
    }

    private class SwapBuilder : ISwap
    {
        private readonly Builder _builder;

        public SwapBuilder(Builder builder) => _builder = builder;
        public IWith Stack(int i) => new WithBuilder(_builder, (grid, with) => grid.Stack(i, with));
        public IWith Band(int i) => new WithBuilder(_builder, (grid, with) => grid.Band(i, with));

        private class WithBuilder : IWith
        {
            private readonly Builder _builder;
            private readonly Func<Grid, int, Grid> _mutation;

            public WithBuilder(Builder builder, Func<Grid, int, Grid> mutation)
            {
                _builder = builder;
                _mutation = mutation;
            }

            public Builder With(int i) => 
                _builder.Add(grid => _mutation(grid, i));
        }
    }

    public Builder Shuffle(string alphabet, string becomes) => 
        Add(grid => grid.Shuffle(alphabet, becomes));

    public Builder Shuffle(string alphabet) =>
        Shuffle(alphabet, alphabet.Shuffle());

    private Builder Add(Func<Grid, Grid> mutator)
    {
        _mutators.Add(mutator);
        return this;
    }

    public Grid Apply(Grid grid) => 
        _mutators.Aggregate(grid, (current, mutator) => mutator(current));

    public Builder Rotate() => Add(grid => grid.Rotate());
}