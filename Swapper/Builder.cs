namespace Swapper;

public class Builder
{
    private readonly List<Func<Grid, Grid>> _mutators = new();

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

    public IStack Stack(int i) => new StackBuilder(this, i);

    private class StackBuilder : IStack
    {
        private readonly Builder _builder;
        private readonly int _stack;

        public StackBuilder(Builder builder, int stack) => (_builder, _stack) = (builder, stack);
        public Builder Swap(int with) => _builder.Add(grid => grid.Stack(_stack, with));
        public Builder Mirror() => _builder.Add(grid => grid.MirrorStack(_stack));
        public Builder Shuffle() => _builder.Add(grid => new Shuffle.Stacks(new Random()).Apply(grid));
    }

    public IBand Band(int band) => new BandBuilder(this, band);

    private class BandBuilder : IBand
    {
        private readonly Builder _builder;
        private readonly int _band;

        public BandBuilder(Builder builder, int band) => (_builder, _band) = (builder, band);
        public Builder Swap(int with) => _builder.Add(grid => grid.Band(_band, with));
        public Builder Mirror() => _builder.Add(grid => grid.MirrorBand(_band));
        public Builder Shuffle() => _builder.Add(grid => new Shuffle.Band(new Random()).Apply(grid));
    }

    public IBands Bands() => new BandsBuilder(this);

    private class BandsBuilder : IBands
    {
        private readonly Builder _builder;

        public BandsBuilder(Builder builder) => _builder = builder;
        public Builder Mirror() => _builder.Add(grid => grid.MirrorBands());
        public Builder Shuffle() => _builder.Add(grid => new Shuffle.Bands(new Random()).Apply(grid));
        public Builder ForEach(Action<IBand> apply) => _builder.Add(grid =>
        {
            var builder = new Builder();
            var bands = grid.Size.Lower().Higher();
            
            for (var band = 0; band < bands; band++)
            {
                apply(new BandBuilder(builder, band));
            }

            return builder.Apply(grid);
        });
    }

    public IStacks Stacks() => new StacksBuilder(this);

    private class StacksBuilder : IStacks
    {
        private readonly Builder _builder;

        public StacksBuilder(Builder builder) => _builder = builder;
        public Builder Mirror() => _builder.Add(grid => grid.MirrorStacks());
        public Builder Shuffle() => _builder.Add(grid => grid);
        public Builder ForEach(Action<IStack> apply) => _builder.Add(grid =>
        {
            var builder = new Builder();
            var stacks = grid.Size.Lower().Lower();
            
            for (var stack = 0; stack < stacks; stack++)
            {
                apply(new StackBuilder(builder, stack));
            }

            return builder.Apply(grid);
        });
    }

    public IColumns Columns() => new ColumnsBuilder(this);

    private class ColumnsBuilder : IColumns
    {
        private readonly Builder _builder;

        public ColumnsBuilder(Builder builder) => _builder = builder;
        public Builder Mirror() => _builder.Add(grid => grid.MirrorColumns());
    }

    public IRows Rows() => new RowsBuilder(this);

    private class RowsBuilder : IRows
    {
        private readonly Builder _builder;

        public RowsBuilder(Builder builder) => _builder = builder;
        public Builder Mirror() => _builder.Add(grid => grid.MirrorRows());
    }
}

public interface IRows : IMirror
{
}

public interface IColumns : IMirror
{
}

public interface IGrid: IShuffle, IMirror
{
}

public interface IBands : IGrid
{
    Builder ForEach(Action<IBand> apply);
}

public interface IStacks : IGrid
{
    Builder ForEach(Action<IStack> apply);
}

public interface IMirror
{
    Builder Mirror();
}

public interface IBand : ISwap, IShuffle, IMirror
{
}

public interface ISwap
{
    Builder Swap(int with);
}

public interface IShuffle
{
    Builder Shuffle();
}

public interface IStack : ISwap, IShuffle, IMirror
{
}