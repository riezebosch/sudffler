using Swapper.Builders;

namespace Swapper;

public class Builder
{
    private readonly List<Func<Grid, Grid>> _mutators = new();
    private readonly Shuffler _shuffle = new(new Random());

    public Builder Shuffle(string alphabet, string with) => 
        Add(grid => _shuffle.Alphabet(grid, alphabet, with));

    public Builder Shuffle(string alphabet) =>
        Add(grid => _shuffle.Alphabet(grid, alphabet));

    public Builder Add(Func<Grid, Grid> mutator)
    {
        _mutators.Add(mutator);
        return this;
    }

    public Grid Apply(Grid grid) => 
        _mutators.Aggregate(grid, (current, mutator) => mutator(current));

    public Builder Rotate() => Add(Swapper.Rotate.Clockwise);

    public IStack Stack(int stack) => new Stack(this, stack);

    public IBand Band(int band) => new Band(this, band);

    public IBands Bands() => new Bands(this);

    public IStacks Stacks() => new Stacks(this);

    public IColumns Columns() => new Columns(this);

    public IRows Rows() => new Rows(this);
}